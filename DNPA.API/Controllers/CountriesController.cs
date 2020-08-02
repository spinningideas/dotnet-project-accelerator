using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DNPA.Business;
using DNPA.Business.Models;
using DNPA.Repositories;
using DNPA.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DNPA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<CountryEntity> _repository;
        private readonly CountriesManager _manager;

        public CountriesController(ILogger<CountriesController> logger, IMapper mapper, IRepository<CountryEntity> repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
            _manager = new CountriesManager(_mapper, _repository);
        }

        [HttpGet("{continentCode}")]
        public async Task<List<Country>> GetByContinentCode(string continentCode)
        {
            return await _manager.GetByContinentCode(continentCode);
        }

        [HttpPost("search")]
        public async Task<List<Country>> Search(CountriesSearch search)
        {
            return await _manager.Search(search.SearchTerm);
        }
    }
}
