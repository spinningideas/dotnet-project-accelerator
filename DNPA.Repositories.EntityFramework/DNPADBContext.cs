using DNPA.Models;
using DNPA.Repositories.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DNPA.Repositories.EntityFramework
{
    public class DNPADBContext : DbContext
    {
        public DNPADBContext(DbContextOptions<DNPADBContext> options) : base(options)
        { }

        public DNPADBContext() : base()
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mapper = new DBContextModelBuilder();
            mapper.BuildModel(modelBuilder);
        }
        
        public DbSet<Continent> Continents { get; set; }

        public DbSet<Country> Countries { get; set; }
    
    }
}
