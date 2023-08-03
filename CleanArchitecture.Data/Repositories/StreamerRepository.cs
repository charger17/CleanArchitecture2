using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infraestructure.Persistence;

namespace CleanArchitecture.Infraestructure.Repositories
{
    public class StreamerRepository : RepositoryBase<Streamer>, IStreamerRepository
    {
        public StreamerRepository(StreamerDbContext context) : base(context)
        {
        }
    }
}
