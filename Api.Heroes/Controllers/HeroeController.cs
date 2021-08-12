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
    public class HeroeController : ControllerBase
    {
        private readonly TESTContext _context;

        public HeroeController(TESTContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all heroes
        /// </summary>
        [HttpGet]
        public ActionResult<List<Heroe>> Get()
        {
            var heroes = _context.Heroes.ToList();
            return heroes;
        }
    }
}
