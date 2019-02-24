using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Services;

namespace SimpleGallery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IService<Image> _imageService;

        public ImagesController(IService<Image> imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            var images = await _imageService.ListAsync();
            return images;
        }
    }
}