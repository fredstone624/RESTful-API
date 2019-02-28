namespace SimpleGallery.API.Domain.Models
{
    public class Photo : BaseModel
    {
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public string AlbumId { get; set; }
        public Album Album { get; set; }
    }
}