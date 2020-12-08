﻿using Application.Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Sieve.Services
{
    public interface ISieveProcessor : ISieveProcessor<SieveModel, FilterTerm, SortTerm>
    {

    }

    public interface ISieveProcessor<TFilterTerm, TSortTerm> : ISieveProcessor<SieveModel<TFilterTerm, TSortTerm>, TFilterTerm, TSortTerm>
        where TFilterTerm : IFilterTerm, new()
        where TSortTerm : ISortTerm, new()
    {

    }

    public interface ISieveProcessor<TSieveModel, TFilterTerm, TSortTerm>
        where TSieveModel : class, ISieveModel<TFilterTerm, TSortTerm>
        where TFilterTerm : IFilterTerm, new()
        where TSortTerm : ISortTerm, new()

    {
        IQueryable<TEntity> Apply<TEntity>(
            TSieveModel model,
            IQueryable<TEntity> source,
            object[] dataForCustomMethods = null,
            bool applyFiltering = true,
            bool applySorting = true,
            bool applyPagination = true);
    }
}
