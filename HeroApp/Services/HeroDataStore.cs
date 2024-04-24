using HeroApp.Models;

namespace HeroApp.Services
{
    public class HeroDataStore
    {
        // 1
        public List<Hero>  Heroes { get; set; } = new List<Hero>();

        // 3, Singleton , wWith static i'm saying that i don't need to instance again regarding the HeroDataStore Class
        public static HeroDataStore Current { get; } = new HeroDataStore();


        // 2
        public HeroDataStore()
        {
            Heroes = new List<Hero>()
            {
                new Hero()
                {
                    Id= 1,
                    Name = "Clark Ken",
                    HeroName = "Superman"
                },
                new Hero()
                {
                    Id = 2,
                    Name= "Dr. Henry",
                    HeroName= "Ant-Man"
                },
                new Hero()
                {
                    Id = 3,
                    Name = "HellBoy",
                    HeroName = "HellBoy"
                },
                new Hero()
                {
                    Id= 4,
                    Name = "Tony Stark",
                    HeroName = "Iron-Man"
                }
            };
        }
    }
}
