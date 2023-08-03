using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {
            
        }

        public async Task<Video> GetVideoByNombre(string nombreVideo)
        {
            return await _context.Videos!.Where(v => v.Nombre.Contains(nombreVideo)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
        {
            return await _context.Videos!.Where(v => v.CreatedBy.Equals(username)).ToListAsync();
        }
    }
}
