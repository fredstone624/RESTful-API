using System.ComponentModel.DataAnnotations;

namespace SimpleGallery.API.Resources
{
    public class SaveImageResource
    {
        [Required]
        public byte[] Bytes { get; set; }

        [Required]
        public string MimeType { get; set; }

        [Required]
        public string PhotoId { get; set; }
    }
}