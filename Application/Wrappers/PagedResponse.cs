using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int IndexFrom { get; set; }
        public bool HasPreviousPage => PageNumber - IndexFrom > 0;
        public bool HasNextPage => PageNumber - IndexFrom + 1 < TotalPages;

        public PagedResponse(T data, int pageNumber, int pageSize, int totalCount, int totalPages)
        {
            Data = data;
            Message = null;
            Successed = true;

            PageSize = pageSize;
            PageNumber = pageNumber;
            Errors = null;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }
    }
}
