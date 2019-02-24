using Microsoft.EntityFrameworkCore;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Persistence.Repositories
{
    public class PhotoRepository : BaseRepository, IRepository<Photo>
    {
        public PhotoRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Photo>> ListAsync()
        {
            return await _context.Photos.ToListAsync();
        }

        public Task AddAsync(Photo value)
        {
            throw new System.NotImplementedException();
        }
    }
}