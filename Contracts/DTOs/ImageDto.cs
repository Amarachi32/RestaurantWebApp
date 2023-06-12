using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs
{
    public class UploadImageModel
    {
        public string Title { get; set; }
        //public IFormFile UploadImage { get; set; }
        public string Tags { get; set; }
    }

    public class GalleryIndexModel
    {

        public IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }
    }

    public class GalleryDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }

        public List<string> Tags { get; set; }
    }

}
