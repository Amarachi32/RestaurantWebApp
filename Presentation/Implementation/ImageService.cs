using Braintree.Exceptions;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Contracts.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class ImageUploadService 
    {

        private readonly IIMageService _imageService;

        public ImageUploadService(IIMageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            return await _imageService.UploadImageAsync(imageFile);
        }

        /*        private IRepositoryWrapper _repository;
                public ImageService(IRepositoryWrapper repository)
                {
                    _repository = repository;
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



                public async Task<ProductResult> DeleteProductAsync(Guid prodId)
                {
                    var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (userId == null)
                        throw new NotFoundException("User not logged in");

                    Product productToDelete = await _productRepo.GetSingleByAsync(p => p.Id == prodId);
                    if (productToDelete == null)
                        throw new NotFoundException($"Invalid product id: {prodId}");
                    if (productToDelete.UserId.ToString() != userId)
                        throw new UnauthorizedAccessException("You are not authorized to delete this product");
                    await _productRepo.DeleteAsync(productToDelete);
                    return (new ProductResult()
                    {
                        Result = true,
                        Message = new List<string>()
                            {
                                "Product has Deleted successful"
                            },

                    });

                }

                public Task<GalleryImage> AddPhoto(IFormFile file)
                {
                    throw new NotImplementedException();
                }

                public Task<string> DeletePhoto(int Id)
                {
                    throw new NotImplementedException();
                }


                private readonly IImageService _imageService;

                public ImageUploadService(IImageService imageService)
                {
                    _imageService = imageService;
                }

                public async Task<string> UploadImageAsync(IFormFile imageFile)
                {
                    return await _imageService.UploadImageAsync(imageFile);
                }
        */

    }
}
