namespace SimpleGallery.API.Resources
{
    public class PhotoResource
    {
        public string Id { get; set; }
        public ImageResource Image { get; set; }
        public AlbumResource Album { get; set; }
    }
}