using Microsoft.AspNetCore.Mvc;
using HeroApp.Models;
using HeroApp.Services;

namespace HeroApp.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class HeroController : ControllerBase
    {
           [HttpGet]

           public ActionResult<IEnumerable<Hero>> GetHeros()
    {
           return Ok(HeroDataStore.Current.Heroes);
    }

    [HttpGet("{heroId}")]
           public ActionResult<Hero> GetHero(int heroId) {

        var hero = HeroDataStore.Current.Heroes.FirstOrDefault(h => h.Id == heroId);
        if (hero == null)
        {
            return NotFound("There is not hero with that Id");
        }
        else
        {
            return Ok(hero);//Gives a 200 status response
        }

           
    }

    [HttpPost]
           public ActionResult<Hero> PostHero(InputHero inputHero)
    {
        var hero = HeroDataStore.Current.Heroes.FirstOrDefault(h => h.Name == inputHero.InputName || h.HeroName == inputHero.InputHeroName);
        if (hero != null)
        {
            return NotFound("There is a hero already using that information");
        }
        else
        {
            //maping
            var maxId = HeroDataStore.Current.Heroes.Max(h=>h.Id);
            var newHero = new Hero()
            {
                Id = maxId+1,
                Name = inputHero.InputName,
                HeroName = inputHero.InputHeroName,
            };

           HeroDataStore.Current.Heroes.Add(newHero);



            //return NoContent();
            //Optional, with the next code i'm giving details about the reponse of the ActionResult method action
            //CreatedAtAction it returns or gives a HTTP positive response about creating objecto like 200 status
            //nameOf(method action) helps to keep the track of the method or value 

            /*Break it down:

             return CreatedAtAction(nameOf(Action Method responsible for the response), route data response, new object)


             */
            return CreatedAtAction(nameof(GetHero), 
            new { heroId = newHero},
            newHero);
        }
    }
    [HttpPut("{heroId}")]

    public ActionResult<Hero> PutHero(int heroId, InputHero inputHero)
    {
        //Hero contains the desire Id
        var hero = HeroDataStore.Current.Heroes.FirstOrDefault(h=>h.Id==heroId);
        if(hero == null)
        {
            return NotFound("There isn't a hero with that info");
        }
        else
        {
            hero.Name = inputHero.InputName;
            hero.HeroName = inputHero.InputHeroName;
        }
        return NoContent();
    }
    [HttpDelete("{heroId}")]
    public ActionResult<Hero> DeleteHero(int heroId)
    {
        var hero = HeroDataStore.Current.Heroes.FirstOrDefault(h=>h.Id==heroId);
        if (hero == null)
        {
            return NotFound("There isn't a hero with that info");
        }
        else
        {
            HeroDataStore.Current.Heroes.Remove(hero);
        }
        return NoContent();
    }

}

