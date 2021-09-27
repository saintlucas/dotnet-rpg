using dotnet_rpg.Data;
using System.Collections.Generic;

namespace dotnet_rpg.Models   
{
    public class Character
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = "Frodo"; 

        public int Hitpoints { get; set; } = 100;

        public int Strenght { get; set; } = 10;

        public int Defence { get; set; } = 10;

        public int Inteligence { get; set; } = 10;

        public RPGClass Class { get; set; } = RPGClass.Knight;

        public User User { get; set; }
        
        public Weapon Weapon{ get; set; }

        public List<Skill> Skills { get; set; }

        public int Fights  { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}