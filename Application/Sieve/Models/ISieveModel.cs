﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sieve.Models
{
    public interface ISieveModel : ISieveModel<IFilterTerm, ISortTerm>
    {

    }

    public interface ISieveModel<TFilterTerm, TSortTerm>
        where TFilterTerm : IFilterTerm
        where TSortTerm : ISortTerm
    {
        string Filters { get; set; }

        string Sorts { get; set; }

        int? Page { get; set; }

        int? PageSize { get; set; }

        List<TFilterTerm> GetFiltersParsed();

        List<TSortTerm> GetSortsParsed();
    }
}
