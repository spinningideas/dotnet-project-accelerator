using AutoMapper;
using DNPA.Business.Models;
using DNPA.Repositories.Models;

namespace DNPA.Business
{  
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<ContinentEntity, Continent>();
            CreateMap<CountryEntity, Country>();
        }
    }
}
