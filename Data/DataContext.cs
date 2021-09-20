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
        
        public DbSet<Character> Characters {get; set;} //enables to query and save rpg characters

        public DbSet<User> Users {get; set;} //creates table Users in database
    }
}