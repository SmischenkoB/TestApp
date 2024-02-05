using BusinessLogic.Models;
using BusinessLogic.Transformers;
using DBLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AirportService : IService<AirportFEModel>
    {
        private IAirportOperations _airportOperations;
        public AirportService(IAirportOperations airportOperations)
        {
            _airportOperations = airportOperations;
        }
        public async Task<AirportFEModel> GetById(int id)
        {
            var airport = await _airportOperations.GetById(id);
             
            return await AirportTransformer.TransformAirportEntityFromDb(airport);
        }
        public async Task<List<AirportFEModel>> GetAll()
        { 
            return _airportOperations.GetAll().Result.Select( i =>  AirportTransformer.TransformAirportEntityFromDb(i).Result).ToList();
        }
        public async Task DeleteById(int id)
        { 
            await _airportOperations.RemoveValueFromDb(await _airportOperations.GetById(id));
        }
    }
}
