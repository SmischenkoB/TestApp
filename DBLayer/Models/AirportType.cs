using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class AirportType
    {
        [Key]
        public int Id {  get; set; }
        public string Name { get; set; }
        public ICollection<Airport> Airports { get; set; }
    }
}
