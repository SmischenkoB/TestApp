using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.DAL
{
    public class AirportOperations : IAirportOperations, IDisposable
    {
        public async Task<Airport> AddValueToDb(Airport value)
        {
            using (var db = new AirportContext())
            {
                await db.Airports.AddAsync(value).AsTask().ContinueWith(i => db.SaveChangesAsync());
                return value;
            }
        }

        public void Dispose()
        {
            return; 
        }

        public Task<List<Airport>> GetAll()
        {
            using (var db = new AirportContext())
            {
                return db.Airports.ToListAsync();
            }
        }

        public Task<Airport> GetById(int id)
        {
            using (var db = new AirportContext())
            {
                return db.Airports.FirstAsync(i => i.AirportId == id);
            }
        }

        public Task RemoveValueFromDb(Airport value)
        {
            using (var db = new AirportContext())
            {
                db.Airports.Remove(value);
                return db.SaveChangesAsync();
            }
        }
    }
}
