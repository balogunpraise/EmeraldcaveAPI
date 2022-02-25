using Emeraldcave.Domain.Common;
using Emeraldcave.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Emeraldcave.Infrastructure.Store.Evaluator
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
       public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;
            if(spec.Criteria != null)
            {
                query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
