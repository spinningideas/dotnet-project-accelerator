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
    public class ContinentsController : ControllerBase
    {
        private readonly ILogger<ContinentsController> _logger;
        private readonly IRepository<Continent> _repository;
        private readonly ContinentsManager _manager;

        public ContinentsController(ILogger<ContinentsController> logger, IRepository<Continent> repository)
        {
            _logger = logger;
            _repository = repository;
            _manager = new ContinentsManager(_repository);
        }

        [HttpGet]
        public async Task<List<Continent>> GetAll()
        {
            return await _manager.GetAll();
        }
    }
}
