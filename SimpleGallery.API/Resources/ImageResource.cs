namespace SimpleGallery.API.Resources
{
    public class ImageResource
    {
        public string Id { get; set; }
        public byte[] Bytes { get; set; }
        public string MimeType { get; set; }
    }
}