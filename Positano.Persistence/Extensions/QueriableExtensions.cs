using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Financiera.Persistence
{
    public static class QueriableExtensions
    {
        public static IQueryable<T> MultipleInclude<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            return includes
                .Aggregate(
                    query.AsQueryable(),
                    (current, include) => current.Include(include)
                );
        }
    }
}
