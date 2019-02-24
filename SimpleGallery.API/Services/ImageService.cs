using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Domain.Services;
using SimpleGallery.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Services
{
    public class ImageService : IService<Image, string>
    {
        private readonly IRepository<Image, string> _imageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IRepository<Image, string> imageRepository, IUnitOfWork unitOfWork)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            return await _imageRepository.ListAsync();
        }

        public async Task<Response<Image>> SaveAsync(Image value)
        {
            try
            {
                await _imageRepository.AddAsync(value);
                await _unitOfWork.CompleteAsync();

                return new Response<Image>(value);
            }
            catch (Exception ex)
            {
                return new Response<Image>($"An error occurred when saving the image: {ex.Message}");
            }
        }

        public async Task<Response<Image>> UpdateAsync(string id, Image value)
        {
            var existingImage = await _imageRepository.FindByIdAsync(id);

            if (existingImage == null)
            {
                return new Response<Image>("Image's not found");
            }

            Array.Copy(value.Bytes, existingImage.Bytes, value.Bytes.Length);
            existingImage.MimeType = value.MimeType;

            try
            {
                _imageRepository.Update(existingImage);
                await _unitOfWork.CompleteAsync();

                return new Response<Image>(existingImage);
            }
            catch (Exception ex)
            {
                return new Response<Image>($"An error occurred when updating the image: {ex.Message}");
            }
        }

        public async Task<Response<Image>> DeleteAsync(string id)
        {
            var existingImage = await _imageRepository.FindByIdAsync(id);

            if (existingImage == null)
            {
                return new Response<Image>("Image's not found");
            }

            try
            {
                _imageRepository.Remove(existingImage);
                await _unitOfWork.CompleteAsync();

                return new Response<Image>(existingImage);
            }
            catch (Exception ex)
            {
                return new Response<Image>($"An error occurred when deleting the image: {ex.Message}");
            }
        }
    }
}