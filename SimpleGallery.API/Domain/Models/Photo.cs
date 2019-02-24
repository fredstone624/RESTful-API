namespace SimpleGallery.API.Domain.Models
{
    public class Photo
    {
        public string Id { get; set; }
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public string AlbumId { get; set; }
        public Album Album { get; set; }
    }
}