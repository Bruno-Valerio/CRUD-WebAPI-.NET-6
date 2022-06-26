using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    { 



        //private static  List<SuperHero> heros = new List<SuperHero>();
        private readonly APIDbcontext dbcontext;

        public SuperHeroController(APIDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuperHeroDetails()
        {
            
            return Ok(await dbcontext.superHeroes.ToListAsync());
        }


        [HttpPost]

        public async Task<IActionResult> AddHero(SuperHero hero)
        {
            var heros = new SuperHero()
            {
                FirstName = hero.FirstName,
                LastName = hero.LastName,
                Place = hero.Place,
                Name = hero.Name,
                Id = hero.Id
            };
            await dbcontext.superHeroes.AddAsync(heros);
            await dbcontext.SaveChangesAsync();
            return Ok(heros);
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateHero([FromRoute]int id,SuperHero hero)
        {
            var hero1 = await dbcontext.superHeroes.FindAsync(id);
            if (hero1 != null)
            {  
                
                hero1.Name = hero.Name;
                hero1.FirstName = hero.FirstName;
                hero1.LastName = hero.LastName;
                hero1.Place = hero.Place;

                await dbcontext.SaveChangesAsync();
                return Ok(hero1);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteHero([FromRoute] int id)
        { 
            var hero= await dbcontext.superHeroes.FindAsync(id);
            if (hero != null)
            {
                dbcontext.superHeroes.Remove(hero);
                await dbcontext.SaveChangesAsync();
                return Ok(hero);
            }
            else
            {
                return BadRequest($"Hero withge the given id {id}  not present");
            }
        }
    }
}
