using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Domain.Services;
using SimpleGallery.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGallery.API.Services
{
    public class ImageService : IService<Image>
    {
        private readonly IRepository<Image, string> _imageRepository;

        public ImageService(IRepository<Image, string> imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public Task<IEnumerable<Image>> ListAsync()
        {
            return _imageRepository.ListAsync();
        }

        public Task<SaveResponse<Image>> SaveAsync(Image value)
        {
            throw new NotImplementedException();
        }
    }
}