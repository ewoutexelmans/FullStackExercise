using System.Linq;

namespace FullStackExercise.Business.Util
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paged<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            var skip = pageIndex * pageSize;
            return skip < 1 ? query.Take(pageSize) : query.Skip(skip).Take(pageSize);
        }
    }
}