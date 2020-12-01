using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces.UnitOfWork.Sorting
{
    public static class OrderByExtensions
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> queryable, string sorts)
        {
            var sort = new SortCollection<TSource>(sorts);
            return sort.Apply(queryable);
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> queryable, params string[] sorts)
        {
            var sort = new SortCollection<TSource>(sorts);
            return sort.Apply(queryable);
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> queryable, string sorts, out SortCollection<TSource> sortCollection)
        {
            sortCollection = new SortCollection<TSource>(sorts);
            return sortCollection.Apply(queryable);
        }
    }
}
