using Microsoft.EntityFrameworkCore;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Persistence.Repositories
{
    public class PhotoRepository : BaseRepository, IRepository<Photo, string>
    {
        public PhotoRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Photo>> ListAsync()
        {
            return await _context.Photos.ToListAsync();
        }

        public async Task AddAsync(Photo value)
        {
            await _context.Photos.AddAsync(value);
        }

        public async Task<Photo> FindByIdAsync(string id)
        {
            return await _context.Photos.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public void Update(Photo value)
        {
            _context.Photos.Update(value);
        }
    }
}