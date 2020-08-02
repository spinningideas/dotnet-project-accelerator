using DNPA.Repositories.Mapping;
using DNPA.Repositories.Models;
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
        
        public DbSet<ContinentEntity> Continents { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }
    
    }
}
