using Microsoft.EntityFrameworkCore;
using dotnet_rpg.Models;
using dotnet_rpg.Data;



namespace dotnet_rpg.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; } //enables to query and save rpg characters

        public DbSet<User> Users { get; set; } //creates table Users in database

        public DbSet<Weapon> Weapons { get; set; } //creates table Waepons in database

        public DbSet<Skill> Skills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Fireball", Damage = 30},
                new Skill { Id = 2, Name = "Frenzy", Damage = 20},
                new Skill { Id = 3, Name = "Blizzard", Damage = 50}
                );
        }
    }

}