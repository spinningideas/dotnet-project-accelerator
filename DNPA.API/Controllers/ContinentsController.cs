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
    public class ContinentsController : ControllerBase
    {        
        private readonly ILogger<ContinentsController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<ContinentEntity> _repository;
        private readonly ContinentsManager _manager;

        public ContinentsController(ILogger<ContinentsController> logger, IMapper mapper, IRepository<ContinentEntity> repository)
        {           
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
            _manager = new ContinentsManager(_mapper, _repository);
        }

        [HttpGet]
        public async Task<List<Continent>> GetAll()
        {
            return await _manager.GetAll();
        }
    }
}
