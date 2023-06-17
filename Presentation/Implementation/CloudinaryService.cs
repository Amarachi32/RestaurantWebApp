using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Interfaces;
using Microsoft.AspNetCore.Http;
using Braintree;
using Microsoft.Extensions.Configuration;

namespace Presentation.Implementation
{
    public class CloudinaryService : IIMageService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration _configur)
        {
            var cloudName = _configur["Cloudinary:CloudName"];
            var apiKey = _configur["Cloudinary:ApiKey"];
            var apiSecret = _configur["Cloudinary:ApiSecret"];

            Account account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);

            /*Account account = new Account("dvqqi8eb7", "362766178859542", "GJ25DDNui6hMgNkLwRFvKqBAn44");
            _cloudinary = new Cloudinary(account);*/
        }

        public async Task<string> UploadImageAsync(IFormFile imageFile)
        {

            
                using (var stream = imageFile.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(imageFile.FileName, stream),
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if (uploadResult != null && !string.IsNullOrEmpty(uploadResult.SecureUrl?.AbsoluteUri))
                {
                    //uploadResult.SecureUri.ToString();
                    return uploadResult.SecureUrl.AbsoluteUri;
                }

                return null;
                }
       /*     
            using (var stream = imageFile.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(imageFile.FileName, stream),
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult.SecureUri.AbsoluteUri;
            }*/
        }

        /*        private readonly Cloudinary _cloudinary;

                public CloudinaryService()
                {
                    Account account = new Account(
                        "your_cloud_name",
                        "your_api_key",
                        "your_api_secret");

                    _cloudinary = new Cloudinary(account);
                }

                public ImageUploadResult UploadImage(string imagePath)
                {
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(imagePath)
                    };

                    return _cloudinary.Upload(uploadParams);
                }

        */
    }
}
