using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNPA.Business.Models
{
	public class PagedResponse<T>
	{
		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public bool HasPreviousPage => CurrentPage > 1;
		public bool HasNextPage => CurrentPage < TotalPages;
		public IList<T> Items { get; set; }

		public PagedResponse(int currentPage, int pageSize)
		{
			CurrentPage = currentPage;
			PageSize = pageSize;
		}

		/// <summary>
		/// Converts an already paged data set
		/// </summary>
		/// <param name="pagedSource"></param>
		/// <param name="totalItems"></param>
		/// <param name="currentPage"></param>
		/// <param name="pageSize"></param>
		public PagedResponse(IEnumerable<T> pagedSource, int totalItems, int currentPage, int pageSize)
		{
			TotalItems = totalItems;
			PageSize = pageSize;
			CurrentPage = currentPage;
			TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

			Items = pagedSource.ToList();
		}

	}
}
