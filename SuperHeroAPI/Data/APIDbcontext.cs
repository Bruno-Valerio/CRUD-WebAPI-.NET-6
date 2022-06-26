using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
    public class APIDbcontext : DbContext
    {
       

        public APIDbcontext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<SuperHero> superHeroes { get; set; }

    }
}
