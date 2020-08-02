using DNPA.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DNPA.Repositories.EntityFramework
{
    public class ContinentsRepository : EFRepository<Continent>
    {
        private readonly DNPADBContext _context;

        public ContinentsRepository(DNPADBContext context): base(context)
        {
            _context = context;
        }

        public async Task<Continent> GetByContinentCode(string continentCode)
        {     
            var continent = await _context.Continents.Where(x => x.ContinentCode == continentCode).FirstOrDefaultAsync();
            if (continent == null)
            {
                return null;
            }
            return continent;
        }

    }
}
