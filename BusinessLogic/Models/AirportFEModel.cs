using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class AirportFEModel
    {
        public int AirportId { get; set; }
        public string IATACode { get; set; }
        public string CountryName { get; set; }
        public string Type { get; set; }
    }
}
