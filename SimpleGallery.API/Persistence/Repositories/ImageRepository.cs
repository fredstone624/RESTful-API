using Microsoft.EntityFrameworkCore;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Persistence.Repositories
{
    public class ImageRepository : BaseRepository, IRepository<Image, string>
    {
        public ImageRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task AddAsync(Image value)
        {
            await _context.Images.AddAsync(value);
        }

        public async Task<Image> FindByIdAsync(string id)
        {
            return await _context.Images.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public void Update(Image value)
        {
            _context.Images.Update(value);
        }
    }
}