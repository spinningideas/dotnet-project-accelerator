using System.Collections.Generic;
using System.Threading.Tasks;
using DNPA.Business;
using DNPA.Models;
using DNPA.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DNPA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly IRepository<Country> _repository;
        private readonly CountriesManager _manager;

        public CountriesController(ILogger<CountriesController> logger, IRepository<Country> repository)
        {
            _logger = logger;
            _repository = repository;
            _manager = new CountriesManager(_repository);
        }

        [HttpGet("{continentCode}")]
        public async Task<List<Country>> GetByContinentCode(string continentCode)
        {
            return await _manager.GetByContinentCode(continentCode);
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<List<Country>> Search(string searchTerm)
        {
            return await _manager.Search(searchTerm);
        }
    }
}
