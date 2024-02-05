using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly ILogger<RoutesController> _logger;
        private readonly IRouteService _routeService;

        public RoutesController(IRouteService routeService, ILogger<RoutesController> logger)
        {
            _routeService = routeService;
            _logger = logger;
        }
        // GET: api/<RoutesController>
        [HttpGet]
        public IEnumerable<RouteFEModel> Get()
        {
            return _routeService.GetAll().Result;
        }

        //// GET api/<RoutesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RoutesController>
        [HttpPost]
        public void Post([FromBody] RouteFEModel value)
        {
            _routeService.Add(value);
        }
    }
}
