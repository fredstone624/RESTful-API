﻿using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Domain.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> ListAsync();
        Task<SaveResponse<Album>> SaveAsync(Album album);
    }
}