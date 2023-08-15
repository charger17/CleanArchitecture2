using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specifications.Directores
{
    public class DirectorForCountingSpecification : BaseSpecification<Director>
    {
        public DirectorForCountingSpecification(DirectorSpecificationParams directorParamas) : base(
                x => string.IsNullOrEmpty(directorParamas.Search) || x.Nombre!.Contains(directorParamas.Search)
                )
        {
            
        }
    }
}
