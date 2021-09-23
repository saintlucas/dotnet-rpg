using System.Runtime.InteropServices;

namespace dotnet_rpg.Models
{
    public class Weapon 
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Damage { get; set; }

        public Character  Character { get; set; }

        public int CharacterId { get; set; }







    }





}
