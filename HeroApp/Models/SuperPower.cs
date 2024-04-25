namespace HeroApp.Models
{
    public class SuperPower
    {
        public int Id { get; set; }
        public string Power { get; set; } = string.Empty;
        public int SkillLvl { get; set; }
        public EPowerLevel PowerLevel { get; set; } 
        public enum EPowerLevel { 
            Low,
            Middle,
            Average,
            Legendary,
            God,
        }

    }
}
