using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Services;
using SimpleGallery.API.Resources;
using SimpleGallery.API.Extensions;
using System.Linq;

namespace SimpleGallery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IService<Album, string> _albumService;
        private readonly IMapper _mapper;

        public AlbumsController(IService<Album, string> albumService, IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AlbumResource>> GetAllAsync()
        {
            var albums = await _albumService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Album>, IEnumerable<AlbumResource>>(albums);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _albumService.FindAsync(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var albumResource = _mapper.Map<Album, AlbumResource>(result.Value);
            return Ok(albumResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAlbumResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages().ToList());
            }

            var albums = _mapper.Map<SaveAlbumResource, Album>(resource);

            var result = await _albumService.SaveAsync(albums);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var albumResource = _mapper.Map<Album, AlbumResource>(result.Value);
            return Ok(albumResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] SaveAlbumResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages().ToList());
            }

            var albums = _mapper.Map<SaveAlbumResource, Album>(resource);
            var result = await _albumService.UpdateAsync(id, albums);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var albumResource = _mapper.Map<Album, AlbumResource>(result.Value);
            return Ok(albumResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _albumService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            var albumResource = _mapper.Map<Album, AlbumResource>(result.Value);
            return Ok(albumResource);
        }
    }
}