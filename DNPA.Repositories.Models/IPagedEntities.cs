
using System.Collections.Generic;

namespace DNPA.Repositories.Models
{
    /// <summary>
    /// Paged set of repository entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedEntities<T>
    {       
        int CurrentPage { get; set; }

        int TotalPages { get; set; }

        int PageSize { get; set; }

        int TotalItems { get; set; }        

        IList<T> Items { get; set; }

        bool HasPreviousPage { get;}

        bool HasNextPage { get; }
    }
}
