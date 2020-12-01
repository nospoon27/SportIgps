using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parameters
{
    public class PagedRequest : IPagedRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PagedRequest()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public PagedRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 1 ? 1 : pageSize > 30 ? 30 : pageSize ;
        }
    }

    public interface IPagedRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
