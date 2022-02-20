using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Emeraldcave.Domain.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; }


        protected void AddIncludes (Expression<Func<T, object>> includes)
        {
            Includes.Add(includes);
        }
    }
}
