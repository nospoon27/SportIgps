using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Application.Interfaces.UnitOfWork.Sorting
{
    public interface ISortProperty<T> : ISort
    {
        new ListSortDirection Direction { get; set; }
        IOrderedQueryable<T> Apply(IQueryable<T> queryable);
    }
}
