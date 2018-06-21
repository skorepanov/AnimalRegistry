using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRegistry.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? DateOfWeighing { get; set; }
    }
}
