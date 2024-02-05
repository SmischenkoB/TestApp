using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly ILogger<AirportController> _logger;
        private readonly IAirportService _airportService;
        public AirportController(IAirportService airportService, 
            ILogger<AirportController> logger)
        {
            _airportService = airportService;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllAirports")]
        public IEnumerable<AirportFEModel> Get()
        {
            return _airportService.GetAll().Result;
        }
        [HttpGet("{id:int}")]
        public AirportFEModel GetAirport(int id) 
        { 
            return _airportService.GetById(id).Result;
        }
    }
}
