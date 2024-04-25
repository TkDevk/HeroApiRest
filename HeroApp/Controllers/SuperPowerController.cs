using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HeroApp.Models;
using HeroApp.Services;

namespace HeroApp.Controllers
{
    [Route("api/hero/{heroId}/[controller]")]
    [ApiController]
    public class SuperPowerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<SuperPower> GetPowers(int heroId)
        {
            var hero = HeroDataStore.Current.Heroes.FirstOrDefault(h => h.Id == heroId);
            if (hero == null)
            {
                return NotFound("Sorry, there isn't nothing related with that number");
            }
            else
            {
                return Ok(hero.SuperPowers);
            }
        }
        [HttpGet("{powerId}")]

        public ActionResult<SuperPower> GetPower(int powerId, int heroId)
        {
            var hero = HeroDataStore.Current.Heroes.FirstOrDefault(h => h.Id == heroId);
            if (hero == null)
            {
                return NotFound("Id Not found");
            }
            else
            {
                var power = hero.SuperPowers.FirstOrDefault(p => p.Id == powerId);
                return Ok(power);
            }
        }
        [HttpPost]

        public ActionResult<SuperPower> PostPower(int heroId, InputSuperPowers inputPower)
        {
            var hero = HeroDataStore.Current.Heroes.FirstOrDefault(h => h.Id == heroId);
            if (hero == null)
            {
                return NotFound("There is not hero related with that info");
            }
            else
            {
                var powerExists = hero.SuperPowers.FirstOrDefault(p => p.Power == inputPower.InputPower);

                if (powerExists != null)
                {
                    return BadRequest("Power already exists");
                }
                else
                {
                    var maxIdP = hero.SuperPowers.Max(x => x?.Id);
                    int newId = maxIdP.HasValue ? maxIdP.Value + 1 : 1;
                    var newPower = new SuperPower()
                    {
                        Id = newId,
                        Power = inputPower.InputPower,
                        //PowerLevel = inputPower.SkillLevel
                    };

                    hero.SuperPowers.Add(newPower);
                    /*
                    return CreatedAtAction(nameof(GetPower),
                new { heroId = heroId, power = newPower.Id },
                newPower
                 );*/
                }
                return NoContent();
               
            }
        }

        [HttpPut("{powerId}")]
        public ActionResult<SuperPower> PutPower(int heroId, int powerId, InputSuperPowers inputSuperPowers)
        {
            var hero = HeroDataStore.Current.Heroes.FirstOrDefault(h => h.Id == heroId);
            if (hero == null)
            {
                return NotFound("The hero doesn't existis");
            }
            else
            {
                var isPower = hero.SuperPowers.FirstOrDefault(p => p.Id == powerId);
                if (isPower == null)
                {
                    return NotFound("That Power doesn't exist");
                }
                else
                {
                    isPower.Power = inputSuperPowers.InputPower;
                    //isPower.PowerLevel = inputSuperPowers.SkillLevel;
                }
            }
            return NoContent();
        }
        [HttpDelete("{powerId}")]
        public ActionResult<SuperPower> DeletePower(int powerId, int heroId)
        {
            var hero = HeroDataStore.Current.Heroes.FirstOrDefault(h=> h.Id == heroId);
            if (hero==null)
            {
                return NotFound("There is not hero with that description");
            }
            else
            {
                var isPower = hero.SuperPowers.FirstOrDefault(p=>p.Id==powerId);
                if (isPower==null)
                {
                    return NotFound("There is not power with that description");
                }
                else
                {
                    hero.SuperPowers.Remove(isPower);
                }
            }
            return NoContent();
        }
    }
}
