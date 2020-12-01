using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Application.Interfaces.UnitOfWork.Sorting
{
    public interface ISort
    {
        string PropertyName { get; }
        ListSortDirection Direction { get; }
    }
}
