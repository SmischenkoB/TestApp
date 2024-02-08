using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DBLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DATA SET UP
            //RUN BEFORE API TEST
            using (var db = new AirportContext())
            {
                //db.Database.EnsureCreatedAsync().Wait();
                //db.Database.EnsureDeletedAsync().Wait();
                //var country = new Country() { Name = "Germany", Id = 17 };
                //db.Countries.Add(country);
                //var airport1 = new Airport() { Country = country, IATACode = "BE1", AirportId = 17 };
                //var airport2 = new Airport() { Country = country, IATACode = "BE2", AirportId = 18 };
                //db.Airports.Add(airport1);
                //db.Airports.Add(airport2);
                //var r1 = new Route() { ArrivalAirportId = airport1.AirportId, DepartureAirportId = airport2.AirportId, Id = 16 };
                //db.Routes.Add(r1);
                //db.AirportTypes.Add(new AirportType { Name = "Arrival Only" });
                //db.AirportTypes.Add(new AirportType { Name = "Departure and Arrival" });
                //db.SaveChanges();
                Console.WriteLine(db.AirportTypes.Count());
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
