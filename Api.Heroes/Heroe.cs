using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Heroes
{
    public class Heroe
    {
        [Key]
        [JsonIgnore]
        [IgnoreDataMember]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}
