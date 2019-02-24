using Microsoft.EntityFrameworkCore;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Persistence.Repositories
{
    public class ImageRepository : BaseRepository, IRepository<Image>
    {
        public ImageRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public Task AddAsync(Image value)
        {
            throw new System.NotImplementedException();
        }
    }
}