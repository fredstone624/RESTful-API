using SimpleGallery.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Domain.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> ListAsync();
    }
}