using DNPA.Repositories.Models;

namespace DNPA.Repositories.EntityFramework
{
    public class CountriesRepository : EFRepository<CountryEntity>
    {
        private readonly DNPADBContext _context;

        public CountriesRepository(DNPADBContext context) : base(context)
        {
            _context = context;
        }    
    }
}
