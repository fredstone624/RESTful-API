using System.ComponentModel.DataAnnotations;

namespace SimpleGallery.API.Resources
{
    public class SavePhotoResource
    {
        [Required]
        public string AlbumId { get; set; }
        
        [Required]
        public string ImageId { get; set; }
    }
}