﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class Airport
    {
        [Key]
        public int AirportId { get; set; }  

        public string IATACode { get; set; }

        public Country Country { get; set; }
        public int AirportTypeId {  get; set; }
        public AirportType AirportType { get; set; }

    }
}
