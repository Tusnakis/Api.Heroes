using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Heroes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Heroes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly TESTContext _context;

        public HeroesController(TESTContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all heroes
        /// </summary>
        [HttpGet]
        public ActionResult<List<Heroe>> GetHeroes()
        {
            var heroes = _context.Heroes.ToList();
            return heroes;
        }

        /// <summary>
        /// Get one heroe by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Heroe>> GetOneHeroe(int id)
        {
            var heroe = await _context.Heroes.FindAsync(id);

            if (heroe == null)
            {
                return NotFound();
            }

            return heroe;
        }

        /// <summary>
        /// Insert an heroe
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Heroe>> PostTodoItem(Heroe heroe)
        {
            _context.Heroes.Add(heroe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOneHeroe), new { id = heroe.Id }, heroe);
        }

        /// <summary>
        /// Update one heroe by id
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroe(int id, Heroe heroe)
        {
            if (id != heroe.Id)
            {
                return BadRequest();
            }

            _context.Entry(heroe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var ids = _context.Heroes.Select(p => p.Id).ToList();
                if (!ids.Contains(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Delete one heroe by id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroe(int id)
        {
            var heroe = await _context.Heroes.FindAsync(id);
            if (heroe == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(heroe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #region Helpers

        //public bool HeroeExists(int id)
        //{
        //    var ids = _context.Heroes.Select(p => p.Id).ToList();
        //    if(ids.Contains(id))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        #endregion
    }
}
