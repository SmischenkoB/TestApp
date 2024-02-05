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
    public class RouteOperations : IRouteOperations, IDisposable
    {
        public async Task<Route> AddValueToDb(Route value)
        {
            using (var db = new AirportContext())
            {
                await db.Routes.AddAsync(value).AsTask().ContinueWith(i => db.SaveChangesAsync());
                return value;
            }
        }

        public void Dispose()
        {
            return;
        }

        public Task<List<Route>> GetAll()
        {
            using (var db = new AirportContext())
            {
                return db.Routes.ToListAsync();
            }
        }

        public Task<Route> GetById(int id)
        {
            using (var db = new AirportContext())
            {
                return db.Routes.FirstAsync(i => i.Id == id);
            }
        }

        public Task RemoveValueFromDb(Route value)
        {
            using (var db = new AirportContext())
            {
                db.Routes.Remove(value);
                return db.SaveChangesAsync();
            }
        }
    }
}
