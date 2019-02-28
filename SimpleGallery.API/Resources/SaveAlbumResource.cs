using System.ComponentModel.DataAnnotations;

namespace SimpleGallery.API.Resources
{
    public class SaveAlbumResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}