using BusinessLogic.Models;
using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Transformers
{
    public static class RouteTransformer
    {
        public static async Task<RouteFEModel> TransformRouteEntityFromDb(Route value)
        {
            RouteFEModel routeFEModel = new RouteFEModel() {
                Id = value.Id, ArrivalAirportId = value.ArrivalAirportId, 
                DepartureAirportId = value.DepartureAirportId };           
            return routeFEModel;
        }
        public static async Task<Route> TransformRouteEntityToDb(RouteFEModel value)
        {
            return new Route() { Id = value.Id, ArrivalAirportId = value.ArrivalAirportId, DepartureAirportId = value.DepartureAirportId };
        }
    }
}
