using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class AirportContext : DbContext
    {
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<AirportType> AirportTypes { get; set; }
        public string DbPath { get; }

        public AirportContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "traveling.db");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Airport>().HasMany(t => t.Departure)
            //    .WithOne(i => i.DepartureAirport)
            //    .HasForeignKey(g => g.DepartureAirportId);
            //modelBuilder.Entity<Airport>().HasMany(t => t.Arrival)
            //    .WithOne(i => i.ArrivalAirport)
            //    .HasForeignKey(j => j.ArrivalAirportId);
            //modelBuilder.Entity<Airport>().HasOne(i => i.Country)
            //    .WithMany(j => j.Airports);
            modelBuilder.Entity<AirportType>().HasMany(i => i.Airports)
                .WithOne(i => i.AirportType)
                .HasForeignKey(fk => fk.AirportTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Country>().HasMany(i => i.Airports)
                .WithOne(i => i.Country)
                .OnDelete(DeleteBehavior.ClientCascade);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={DbPath}");
    }
}
