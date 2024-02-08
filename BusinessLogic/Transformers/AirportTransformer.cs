using BusinessLogic.Models;
using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Transformers
{
    public static class AirportTransformer
    {
        public static async Task<AirportFEModel> TransformAirportEntityFromDb(Airport airport)
        {
            AirportFEModel airportFEModel = new AirportFEModel() { AirportId = airport.AirportId, CountryName = airport.Country?.Name, IATACode = airport.IATACode };
            airportFEModel.Type = airport.AirportType.Name;
            return airportFEModel;
        }
        public static async Task<Airport> TransformAirportEntityToDb(AirportFEModel airport)
        {
            // add country Object after adding dbContext
            return new Airport() { AirportId = airport.AirportId, IATACode = airport.IATACode, AirportTypeId = airport.AirportId };
        }
    }
}
