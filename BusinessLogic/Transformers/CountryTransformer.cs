using BusinessLogic.Models;
using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Transformers
{
    public class CountryTransformer
    {
        public static async Task<CountryFEModel> TransformCountryEntityFromDb(Country value)
        {
            CountryFEModel routeEfModel = new CountryFEModel() { Id = value.Id, Name = value.Name};
           
            return routeEfModel;
        }
        public static async Task<Country> TransformCountryEntityToDb(CountryFEModel value)
        {
            return new Country() { Id = value.Id, Name = value.Name };
        }
    }
}
