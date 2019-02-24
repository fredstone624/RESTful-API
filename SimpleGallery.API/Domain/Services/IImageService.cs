using SimpleGallery.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Domain.Services
{
    interface IImageService
    {
        Task<IEnumerable<Image>> ListAsync();
    }
}