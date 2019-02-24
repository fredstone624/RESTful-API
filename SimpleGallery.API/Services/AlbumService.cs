using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Domain.Services;
using SimpleGallery.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Services
{
    public class AlbumService : IService<Album, string>
    {
        private readonly IRepository<Album, string> _albumRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AlbumService(IRepository<Album, string> albumRepository, IUnitOfWork unitOfWork)
        {
            _albumRepository = albumRepository;
            _unitOfWork = unitOfWork;
        }
        
        public Task<IEnumerable<Album>> ListAsync()
        {
            return _albumRepository.ListAsync();
        }

        public async Task<SaveResponse<Album>> SaveAsync(Album album)
        {
            try
            {
                await _albumRepository.AddAsync(album);
                await _unitOfWork.CompleteAsync();

                return new SaveResponse<Album>(album);
            }
            catch (Exception ex)
            {
                return new SaveResponse<Album>($"An error occurred when saving the album: {ex.Message}");
            }
        }

        public Task<SaveResponse<Album>> UpdateAsync(string id, Album value)
        {
            throw new NotImplementedException();
        }
    }
}