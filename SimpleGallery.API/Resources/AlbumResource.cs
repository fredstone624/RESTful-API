namespace SimpleGallery.API.Resources
{
    public class AlbumResource
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ulong NumberOfVisitor { get; set; }
    }
}