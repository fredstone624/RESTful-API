using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Domain.Services;
using SimpleGallery.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Services
{
    public class PhotoService : IService<Photo, string>
    {
        private readonly IRepository<Photo, string> _photoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PhotoService(IRepository<Photo, string> photoRepository, IUnitOfWork unitOfWork)
        {
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Photo>> ListAsync()
        {
            return await _photoRepository.ListAsync();
        }

        public async Task<Response<Photo>> FindAsync(string id)
        {
            var existingPhoto = await _photoRepository.FindByIdAsync(id);

            if (existingPhoto == null)
            {
                return new Response<Photo>("Photo's not found");
            }

            return new Response<Photo>(existingPhoto);
        }

        public async Task<Response<Photo>> SaveAsync(Photo value)
        {
            try
            {
                await _photoRepository.AddAsync(value);
                await _unitOfWork.CompleteAsync();

                return new Response<Photo>(value);
            }
            catch (Exception ex)
            {
                return new Response<Photo>($"An error occurred when saving the photo: {ex.Message}");
            }
        }

        public async Task<Response<Photo>> UpdateAsync(string id, Photo value)
        {
            var existingPhoto = await _photoRepository.FindByIdAsync(id);

            if (existingPhoto == null)
            {
                return new Response<Photo>("Photo's not found");
            }

            existingPhoto.AlbumId = value.AlbumId;
            existingPhoto.ImageId = value.ImageId;

            try
            {
                _photoRepository.Update(existingPhoto);
                await _unitOfWork.CompleteAsync();

                return new Response<Photo>(existingPhoto);
            }
            catch (Exception ex)
            {
                return new Response<Photo>($"An error occurred when updating the photo: {ex.Message}");
            }
        }

        public async Task<Response<Photo>> DeleteAsync(string id)
        {
            var existingPhoto = await _photoRepository.FindByIdAsync(id);

            if (existingPhoto == null)
            {
                return new Response<Photo>("Photo's not found");
            }

            try
            {
                _photoRepository.Remove(existingPhoto);
                await _unitOfWork.CompleteAsync();

                return new Response<Photo>(existingPhoto);
            }
            catch (Exception ex)
            {
                return new Response<Photo>($"An error occurred when deleting the photo: {ex.Message}");
            }
        }
    }
}