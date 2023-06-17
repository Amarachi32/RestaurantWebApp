using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IIMageService
    {
        Task<string> UploadImageAsync(IFormFile imageFile);
     //   IEnumerable<GalleryImage> GetAll();
      //  Task<GalleryImage> AddPhoto(IFormFile file);
       // Task<string> DeletePhoto(int Id);
       // IEnumerable<GalleryImage> GetWithTag(string tag);
       // GalleryImage GetById(int id);

    }
}
