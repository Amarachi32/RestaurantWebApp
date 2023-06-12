/*using Contracts.Interfaces;
using Domain.Entities;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class ImageService: IImageService
    {
        private IRepositoryWrapper _repository;
        public ImageService(IRepositoryWrapper repository)
        {
            _repository= repository;
        }

        public IEnumerable<GalleryImage> GetAll()
        {
           return _repository.GalleryImages.Include(x => x.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return GetAll().Where(img => img.Id == id).First();

            //return _ctx.GalleryImages.Find(id);
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }
    }
}
*/