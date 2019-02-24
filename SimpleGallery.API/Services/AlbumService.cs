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

        public async Task<Response<Album>> SaveAsync(Album value)
        {
            try
            {
                await _albumRepository.AddAsync(value);
                await _unitOfWork.CompleteAsync();

                return new Response<Album>(value);
            }
            catch (Exception ex)
            {
                return new Response<Album>($"An error occurred when saving the album: {ex.Message}");
            }
        }

        public async Task<Response<Album>> UpdateAsync(string id, Album value)
        {
            var existingAlbum = await _albumRepository.FindByIdAsync(id);

            if (existingAlbum == null)
            {
                return new Response<Album>("Album's not found");
            }

            existingAlbum.Name = value.Name;
            existingAlbum.Description = value.Description;
            existingAlbum.NumberOfVisitor = value.NumberOfVisitor;

            try
            {
                _albumRepository.Update(existingAlbum);
                await _unitOfWork.CompleteAsync();

                return new Response<Album>(existingAlbum);
            }
            catch (Exception ex)
            {
                return new Response<Album>($"An error occurred when updating the album: {ex.Message}");
            }
        }

        public async Task<Response<Album>> DeleteAsync(string id)
        {
            var existingAlbum = await _albumRepository.FindByIdAsync(id);

            if (existingAlbum == null)
            {
                return new Response<Album>("Album's not found");
            }

            try
            {
                _albumRepository.Remove(existingAlbum);
                await _unitOfWork.CompleteAsync();

                return new Response<Album>(existingAlbum);
            }
            catch (Exception ex)
            {
                return new Response<Album>($"An error occurred when deleting the album: {ex.Message}");
            }
        }
    }
}