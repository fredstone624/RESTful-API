using System.ComponentModel.DataAnnotations;

namespace SimpleGallery.API.Resources
{
    public class SaveAlbumResource
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public ulong NumberOfVisitor { get; set; }
    }
}