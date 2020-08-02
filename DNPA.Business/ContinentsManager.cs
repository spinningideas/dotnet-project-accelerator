
using DNPA.Models;
using DNPA.Repositories;
using LinqKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNPA.Business
{
    public class ContinentsManager
    {
        private readonly IRepository<Continent> _repository;

        public ContinentsManager(IRepository<Continent> repository)
        {
            _repository = repository;
        }

        public async Task<List<Continent>> GetAll()
        {
            var condition = PredicateBuilder.New<Continent>(true);
            return await _repository.FindMany(condition);
        }
    }
}
