using System.ComponentModel.DataAnnotations;

namespace SimpleGallery.API.Resources
{
    public class SaveImageResource
    {
        [Required]
        public string Url { get; set; }

        [Required]
        public string PhotoId { get; set; }
    }
}