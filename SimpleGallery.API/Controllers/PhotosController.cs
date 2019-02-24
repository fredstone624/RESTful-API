﻿using System;
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
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Photo>> GetAllAsync()
        {
            var photos = await _photoService.ListAsync();
            return photos;
        }
    }
}