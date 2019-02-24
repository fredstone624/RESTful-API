using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Services;
using SimpleGallery.API.Extensions;
using SimpleGallery.API.Resources;

namespace SimpleGallery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IService<Photo, string> _photoService;
        private readonly IMapper _mapper;

        public PhotosController(IService<Photo, string> photoService, IMapper mapper)
        {
            _photoService = photoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PhotoResource>> GetAllAsync()
        {
            var photos = await _photoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoResource>>(photos);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePhotoResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages().ToList());
            }

            var photos = _mapper.Map<SavePhotoResource, Photo>(resource);

            var result = await _photoService.SaveAsync(photos);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var photoResource = _mapper.Map<Photo, PhotoResource>(result.Value);
            return Ok(photoResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] SavePhotoResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages().ToList());
            }

            var photos = _mapper.Map<SavePhotoResource, Photo>(resource);
            var result = await _photoService.UpdateAsync(id, photos);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var photoResource = _mapper.Map<Photo, PhotoResource>(result.Value);
            return Ok(photoResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _photoService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var photoResource = _mapper.Map<Photo, PhotoResource>(result.Value);
            return Ok(photoResource);
        }
    }
}