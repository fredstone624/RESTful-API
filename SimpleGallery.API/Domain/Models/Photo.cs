namespace SimpleGallery.API.Domain.Models
{
    public class Photo
    {
        public string Id { get; set; }
        public byte[] Image { get; set; }
        public string ImageMimeType { get; set; }
        public string AlbumId { get; set; }
        public Album Album { get; set; }
    }
}