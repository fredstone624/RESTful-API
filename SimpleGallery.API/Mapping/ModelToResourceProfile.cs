using AutoMapper;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Resources;

namespace SimpleGallery.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Album, AlbumResource>();
        }
    }
}