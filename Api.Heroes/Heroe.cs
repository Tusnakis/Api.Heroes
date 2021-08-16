using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Heroes
{
    public class Heroe
    {
        [Key]
        public int Id { get; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}
