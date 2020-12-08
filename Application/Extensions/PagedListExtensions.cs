using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Extensions
{
    public static class PagedListExtensions
    {
        public static PagedResponse<IList<T>> ToPagedResponse<T>(this IPagedList<T> source)
        {
            return new PagedResponse<IList<T>>(source.Items, source.PageIndex, source.PageSize, source.TotalCount, source.TotalPages);
        }

        public static PagedResponse<IList<M>> ToPagedResponseWithMap<T, M>(this IPagedList<T> source, IMapperBase mapper)
        {
            return new PagedResponse<IList<M>>(mapper.Map<IList<M>>(source), source.PageIndex, source.PageSize, source.TotalCount, source.TotalPages);
        }
    }
}
