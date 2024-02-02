using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    [Index(nameof(Name), IsUnique = true)]
    internal class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Airport> Airports { get; set; }
    }
}
