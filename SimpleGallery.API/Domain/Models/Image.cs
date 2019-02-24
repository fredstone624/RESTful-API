using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGallery.API.Domain.Models
{
    public class Image
    {
        public string Id { get; set; }
        public byte[] Bytes { get; set; }
        public string BytesMimeType { get; set; }
        public string PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
