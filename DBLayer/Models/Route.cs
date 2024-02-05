using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        public int DepartureAirportId { get; set; }
        public Airport DepartureAirport { get; set; }
        public int ArrivalAirportId { get; set; }
        public Airport ArrivalAirport { get; set; }

    }
}
