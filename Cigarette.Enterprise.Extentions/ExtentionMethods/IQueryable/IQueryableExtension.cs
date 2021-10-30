using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.Extentions.ExtentionMethods.IQueryable
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Paged<T>(this IQueryable<T> source, int page,
                                                                        int pageSize)
        {
            return source
              .Skip((page - 1) * pageSize)
              .Take(pageSize);
        }
    }
}
