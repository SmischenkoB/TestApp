using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService, ILogger<CountriesController> logger)
        {
            _countryService = countryService;
            _logger = logger;
        }
        // GET: api/<CountriesController>
        [HttpGet]
        public IEnumerable<CountryFEModel> Get()
        {
            return _countryService.GetAll().Result;
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        public CountryFEModel Get(int id)
        {
            return _countryService.GetById(id).Result;
        }

        // POST api/<CountriesController>
        [HttpPost]
        public void Post([FromBody] string Name)
        {
            _countryService.Add(new CountryFEModel() {  Name = Name });
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _countryService.DeleteById(id);
        }
    }
}
