using HeroApp.Models;

namespace HeroApp.Services
{
    public class HeroDataStore
    {
        // 1
        public List<Hero>  Heroes { get; set; } = new List<Hero>();

        // 3, Singleton, With static i'm saying that i don't need to instance again regarding the HeroDataStore Class, only instance by one and only that
        public static HeroDataStore Current { get; } = new HeroDataStore();


        // 2
        public HeroDataStore()
        {
            Heroes = new List<Hero>()
            {
                new Hero()
                {
                    Id= 1,
                    Name = "Clark Kent",
                    HeroName = "Superman",
                    SuperPowers = new List<SuperPower>()
                    {
                        new SuperPower()
                        {
                            Id = 1,
                            Power = "Flight",
                            PowerLevel= SuperPower.EPowerLevel.God
                        },
                        new SuperPower()
                        {
                            Id = 2,
                            Power = "Super Strength",
                            PowerLevel= SuperPower.EPowerLevel.God
                        },
                        new SuperPower()
                        {
                            Id = 3,
                            Power = "Ray",
                            PowerLevel= SuperPower.EPowerLevel.God
                        },
                        new SuperPower()
                        {
                            Id = 4,
                            Power = "Agility",
                            PowerLevel= SuperPower.EPowerLevel.God
                        }
                    }
                },
                new Hero()
                {
                    Id = 2,
                    Name= "Dr. Henry",
                    HeroName= "Ant-Man",
                    SuperPowers = new List<SuperPower>()
                    {
                        new SuperPower()
                        {
                            Id = 1,
                            Power = "Super speed",
                            PowerLevel= SuperPower.EPowerLevel.Average
                        },
                        new SuperPower()
                        {
                            Id = 2,
                            Power = "Height Manipulation",
                            PowerLevel= SuperPower.EPowerLevel.God
                        },
                        new SuperPower()
                        {
                            Id = 3,
                            Power = "Super Jump",
                            PowerLevel= SuperPower.EPowerLevel.Legendary
                        }
                    }
                },
                new Hero()
                {
                    Id = 3,
                    Name = "HellBoy",
                    HeroName = "HellBoy",
                    SuperPowers = new List<SuperPower>()
                    {
                        new SuperPower()
                        {
                            Id = 1,
                            Power = "Super Jump",
                            PowerLevel= SuperPower.EPowerLevel.Average
                        },
                        new SuperPower()
                        {
                            Id = 2,
                            Power = "Super Strength",
                            PowerLevel= SuperPower.EPowerLevel.Legendary
                        },
                        new SuperPower()
                        {
                            Id = 3,
                            Power = "Stylish",
                            PowerLevel= SuperPower.EPowerLevel.God
                        },
                    }
                },
                new Hero()
                {
                    Id= 4,
                    Name = "Tony Stark",
                    HeroName = "Iron-Man",
                    SuperPowers = new List<SuperPower>()
                    {
                        new SuperPower()
                        {
                            Id = 1,
                            Power = "Flight",
                            PowerLevel= SuperPower.EPowerLevel.Average
                        },
                        new SuperPower()
                        {
                            Id = 2,
                            Power = "Technoloy",
                            PowerLevel= SuperPower.EPowerLevel.God
                        },
                        new SuperPower()
                        {
                            Id = 3,
                            Power = "Strenght",
                            PowerLevel= SuperPower.EPowerLevel.Average
                        }
                    }
                }
            };
        }
    }
}
