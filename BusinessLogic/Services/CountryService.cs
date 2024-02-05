using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Transformers;
using DBLayer.DAL;
using DBLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CountryService : ICountryService
    {
        private ICountryOperations _countryOperation;
        private IAirportOperations _airportOperation;
        public CountryService(ICountryOperations countryOperations, IAirportOperations airportOperation)
        {
            _countryOperation = countryOperations;
            _airportOperation = airportOperation;
        }

        public async Task<CountryFEModel> Add(CountryFEModel value)
        {
            if(_countryOperation.GetAll().Result.Where(i => i.Id == value.Id).Count() > 0)
            { throw new ArgumentException("country already exists"); }

            await _countryOperation.AddValueToDb(await CountryTransformer.TransformCountryEntityToDb(value));
            return value;
        }

        public async Task DeleteById(int id)
        {
            if (_countryOperation.GetAll().Result.Where(i => i.Id == id).Count() == 0)
            { throw new ArgumentException("country could not be found"); }

            if (_airportOperation.GetAll().Result.Where(i => i.Country.Id == id).Count() > 0)
            { throw new ArgumentException("country in use for an airport cannot be deleted"); }

            await _countryOperation.RemoveValueFromDb(await _countryOperation.GetById(id));
        }

        public async Task<List<CountryFEModel>> GetAll()
        {
            return _countryOperation.GetAll().Result.Select(i => CountryTransformer.TransformCountryEntityFromDb(i).Result).ToList();
        }

        public async Task<CountryFEModel> GetById(int id)
        {
            var country = await _countryOperation.GetById(id);
            
            return await CountryTransformer.TransformCountryEntityFromDb(country);
        }
    }
}
