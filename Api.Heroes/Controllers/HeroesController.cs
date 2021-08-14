using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Heroes.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
