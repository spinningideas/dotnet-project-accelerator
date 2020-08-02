using DNPA.Models;

namespace DNPA.Repositories.EntityFramework
{
    public class CountriesRepository : EFRepository<Continent>
    {
        private readonly DNPADBContext _context;

        public CountriesRepository(DNPADBContext context) : base(context)
        {
            _context = context;
        }    
    }
}
