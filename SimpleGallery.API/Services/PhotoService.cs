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
    public class PhotoService : IService<Photo>
    {
        private readonly IRepository<Photo, string> _photoRepository;

        public PhotoService(IRepository<Photo, string> photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public Task<IEnumerable<Photo>> ListAsync()
        {
            return _photoRepository.ListAsync();
        }

        public Task<SaveResponse<Photo>> SaveAsync(Photo value)
        {
            throw new NotImplementedException();
        }
    }
}
