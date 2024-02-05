using DBLayer.Models;
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
               
                var country = new Country() { Name = "Germany", Id = 17 };
                db.Countries.Add(country);
                var airport1 = new Airport() { Country = country, IATACode = "BE1", AirportId = 17 };
                var airport2 = new Airport() { Country = country, IATACode = "BE2", AirportId = 18 };
                db.Airports.Add(airport1);
                db.Airports.Add(airport2);
                var r1 = new Route() { ArrivalAirportId = airport1.AirportId, DepartureAirportId = airport2.AirportId, Id = 16 };
                db.Routes.Add(r1);
                db.SaveChanges();
                Console.WriteLine(db.Countries.Count());
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
