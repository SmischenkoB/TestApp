using DBLayer.Interfaces;
using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.DAL
{
    public class CountryOperations : ICountryOperations, IDisposable
    {
        public async Task<Country> AddValueToDb(Country value)
        {
            using (var db = new AirportContext())
            {
                await db.Countries.AddAsync(value).AsTask().ContinueWith(i => db.SaveChangesAsync());
                return value;
            }
        }

        public void Dispose()
        {
            return;
        }

        public Task<List<Country>> GetAll()
        {
            using (var db = new AirportContext())
            {
                return db.Countries.ToListAsync();
            }
        }

        public Task<Country> GetById(int id)
        {
            using (var db = new AirportContext())
            {
                return db.Countries.FirstAsync(i => i.Id == id);
            }
        }

        public Task RemoveValueFromDb(Country value)
        {
            using (var db = new AirportContext())
            {
                db.Countries.Remove(value);
                return db.SaveChangesAsync();
            }
        }
    }
}
