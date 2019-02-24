using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGallery.API.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepository<Photo> _photoRepository;

        public PhotoService(IRepository<Photo> photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public Task<IEnumerable<Photo>> ListAsync()
        {
            return _photoRepository.ListAsync();
        }
    }
}
