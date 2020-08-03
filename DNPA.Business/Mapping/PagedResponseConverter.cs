using AutoMapper;
using DNPA.Business.Models;
using DNPA.Repositories.Models;
using System.Collections.Generic;

namespace DNPA.Business.Mapping
{
    public class PagedResponseConverter<TSource, TDestination> : ITypeConverter<PagedEntities<TSource>, PagedResponse<TDestination>> where TSource : class where TDestination : class
    {
        public PagedResponse<TDestination> Convert(PagedEntities<TSource> source, PagedResponse<TDestination> destination, ResolutionContext context)
        {
            var collection = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source.Items);

            return new PagedResponse<TDestination>(collection, source.TotalItems, source.CurrentPage, source.PageSize);
        }
    }
}
