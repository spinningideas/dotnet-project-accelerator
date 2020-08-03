using AutoMapper;
using DNPA.Business.Models;
using DNPA.Repositories.Models;

namespace DNPA.Business.Mapping
{  
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<ContinentEntity, Continent>();
            CreateMap<CountryEntity, Country>();
            CreateMap(typeof(PagedEntities<>), typeof(PagedResponse<>)).ConvertUsing(typeof(PagedResponseConverter<,>));
        }
    }
}
