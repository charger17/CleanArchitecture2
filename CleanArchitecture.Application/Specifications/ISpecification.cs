using System.Linq.Expressions;

namespace CleanArchitecture.Application.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get;}

    }
}
