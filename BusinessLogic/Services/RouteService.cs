using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Transformers;
using DBLayer.Interfaces;
using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class RouteService : IRouteService
    {
        private IRouteOperations _routeOperations;
        private IAirportOperations _airportOperations;

        public RouteService(IRouteOperations routeOperations, IAirportOperations airportOperations)
        {
            _routeOperations = routeOperations;
            _airportOperations = airportOperations;
        }

        public async Task<RouteFEModel> Add(RouteFEModel value)
        {
            if (_routeOperations.GetAll().Result.
                Where(i => i.DepartureAirportId == value.DepartureAirportId 
                && i.ArrivalAirportId == value.ArrivalAirportId).Count() > 0) 
            {
                throw new ArgumentException("route already exists");
            }

            if(_airportOperations.GetById(value.ArrivalAirportId) == null 
                || _airportOperations.GetById(value.DepartureAirportId) == null)
            {
                throw new ArgumentException("airports not exists");
            }

            if(_airportOperations.GetById(value.DepartureAirportId).Result?.Departure.Count == 0)
            {
                throw new ArgumentException("airports type is wrong");
            }
            await _routeOperations.AddValueToDb(await RouteTransformer.TransformRouteEntityToDb(value));
            return value;
        }

        public async Task DeleteById(int id)
        {
            await _routeOperations.RemoveValueFromDb(await _routeOperations.GetById(id));
        }

        public async Task<List<RouteFEModel>> GetAll()
        {
            return _routeOperations.GetAll().Result.Select(i => RouteTransformer.TransformRouteEntityFromDb(i).Result).ToList();
        }

        public async Task<RouteFEModel> GetById(int id)
        {
            var route = await _routeOperations.GetById(id);

            return await RouteTransformer.TransformRouteEntityFromDb(route);
        }
    }
}
