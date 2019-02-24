using Microsoft.EntityFrameworkCore;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Persistence.Repositories
{
    public class AlbumRepository : BaseRepository, IRepository<Album>
    {
        public AlbumRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Album>> ListAsync()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task AddAsync(Album value)
        {
            await _context.Albums.AddAsync(value);
        }
    }
}