using DNPA.Models;
using DNPA.Repositories;
using LinqKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNPA.Business
{
    public class CountriesManager
    {
        private readonly IRepository<Country> _repository;

        public CountriesManager(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public async Task<List<Country>> GetByContinentCode(string continentCode)
        {
            var condition = PredicateBuilder.New<Country>(true);
            condition.Start(c => c.ContinentCode == continentCode);
            return await _repository.FindMany(condition);
        }

        public async Task<List<Country>> Search(string searchTerm)
        {
            var condition = PredicateBuilder.New<Country>(true);
            condition.Start(c => c.CountryName.Contains(searchTerm));
            condition.Or(c => c.Capital.Contains(searchTerm));

            return await _repository.FindMany(condition);
        }

    }
}
