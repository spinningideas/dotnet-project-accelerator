using DNPA.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DNPA.Repositories.EntityFramework
{
    public class ContinentsRepository : EFRepository<ContinentEntity>
    {
        private readonly DNPADBContext _context;

        public ContinentsRepository(DNPADBContext context): base(context)
        {
            _context = context;
        }

        public async Task<ContinentEntity> GetByContinentCode(string continentCode)
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
