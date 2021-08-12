using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Heroes.Data
{
    public class TESTContext : DbContext
    {
        public TESTContext(DbContextOptions<TESTContext> options) : base(options)
        {
        }

        public DbSet<Heroe> Heroes { get; set; }
    }
}
