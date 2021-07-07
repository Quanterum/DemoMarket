using System.Linq;
using Domain.Common;

namespace Application.Common.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<TEntity> ExecutePageFilter<TEntity>(this IQueryable<TEntity> source, int page = 1, int take = 15)
        {
            var skip = page < 1 ? 0 : (page - 1) * take;
            return source.Skip(skip).Take(take);
        }
        
        public static IQueryable<TEntity> ExecuteNameFilter<TEntity>(this IQueryable<TEntity> source, string name) where TEntity : BaseEntity => 
            string.IsNullOrEmpty(name) ? source : source.Where(x => x.Name.Contains(name));
    }
}