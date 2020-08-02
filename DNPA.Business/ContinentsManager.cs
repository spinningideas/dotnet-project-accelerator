
using AutoMapper;
using DNPA.Business.Models;
using DNPA.Repositories;
using DNPA.Repositories.Models;
using LinqKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNPA.Business
{
    public class ContinentsManager
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ContinentEntity> _repository;        

        public ContinentsManager(IMapper mapper, IRepository<ContinentEntity> repository)
        {           
            _mapper = mapper;             
            _repository = repository;
        }

        public async Task<List<Continent>> GetAll()
        {
            var condition = PredicateBuilder.New<ContinentEntity>(true);
            var continentsEntities = await _repository.FindMany(condition);
            var continents = _mapper.Map<List<Continent>>(continentsEntities);
            return continents;
        }
    }
}
