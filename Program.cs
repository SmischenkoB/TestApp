using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DBLayer.DAL;
using DBLayer.Interfaces;

namespace TestApiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAirportOperations, AirportOperations>();
            builder.Services.AddScoped<ICountryOperations, CountryOperations>();
            builder.Services.AddScoped<IRouteOperations, RouteOperations>();
            builder.Services.AddScoped<IAirportService, AirportService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<IRouteService, RouteService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
