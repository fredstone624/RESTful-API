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
    public class ImagesController : ControllerBase
    {
        private readonly IService<Image, string> _imageService;
        private readonly IMapper _mapper;

        public ImagesController(IService<Image, string> imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ImageResource>> GetAllAsync()
        {
            var images = await _imageService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Image>, IEnumerable<ImageResource>>(images);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _imageService.FindAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var imageResource = _mapper.Map<Image, ImageResource>(result.Value);
            return Ok(imageResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveImageResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages().ToList());
            }

            var images = _mapper.Map<SaveImageResource, Image>(resource);

            var result = await _imageService.SaveAsync(images);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var imageResource = _mapper.Map<Image, ImageResource>(result.Value);
            return Ok(imageResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] SaveImageResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages().ToList());
            }

            var images = _mapper.Map<SaveImageResource, Image>(resource);
            var result = await _imageService.UpdateAsync(id, images);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var imageResource = _mapper.Map<Image, ImageResource>(result.Value);
            return Ok(imageResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _imageService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var imageResource = _mapper.Map<Image, ImageResource>(result.Value);
            return Ok(imageResource);
        }
    }
}