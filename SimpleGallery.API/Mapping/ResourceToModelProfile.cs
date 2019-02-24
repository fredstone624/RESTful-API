using AutoMapper;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Resources;

namespace SimpleGallery.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAlbumResource, Album>();
            CreateMap<SavePhotoResource, Photo>();
            CreateMap<SaveImageResource, Image>();
        }
    }
}