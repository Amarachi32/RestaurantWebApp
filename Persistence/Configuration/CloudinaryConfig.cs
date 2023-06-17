using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Presentation.Implementation;
using Presentation.Interfaces;
//using Cloudinary.AspNetCore;

namespace Persistence.Configuration
{
    public static class CloudinaryConfig
    {

        /*        public static void ConfigureCloudinary(this IServiceCollection services, IConfiguration config)
                {
                    var cloudinaryConfig = config.GetSection("Cloudinary");
                    services.Configure<CloudinarySettings>(cloudinaryConfig);

                  *//*  var cloudinaryConfig = config.GetSection("Cloudinary");
                    var cloudinarySettings = new CloudinarySettings
                    {
                        CloudName = cloudinaryConfig["cloud_name"],
                        ApiKey = cloudinaryConfig["api_key"],
                        ApiSecret = cloudinaryConfig["api_secret"]
                    };

                    services.AddCloudinary(cloudinarySettings);*//*
                }*/


        public static void ConfigCloudinary(this IServiceCollection _services)
        {
            //var cloudinaryConfig = _configuration.GetSection("Cloudinary");
            //_services.Configure<CloudinarySettings>(cloudinaryConfig);


/*            var cloudinarySettings = configuration.GetSection("Cloudinary").Get<CloudinarySettings>();
            var cloudinary = new Cloudinary(new Account(cloudinarySettings.CloudName, cloudinarySettings.ApiKey, cloudinarySettings.ApiSecret));
            _services.AddSingleton(cloudinary);*/

            /*   _services.AddSingleton<IIMageService>(sp =>
                   new CloudinaryService(
                       _configuration["Cloudinary:CloudName"],
                       _configuration["Cloudinary:ApiKey"],
                       _configuration["Cloudinary:ApiSecret"]
                   ));*/
            _services.AddScoped<IIMageService, CloudinaryService>();
            _services.AddScoped<ImageUploadService>();
          //  _services.AddScoped<ImageUploadService>();
        }

    }
}


/* var cloudinaryConfig = config.GetSection("Cloudinary");
   service.Configure<CloudinarySettings>(cloudinaryConfig);*/

/*      var cloudinarySettings = new CloudinarySettings
      {
          CloudName = config.GetValue<string>("Cloudinary:CloudName"),
          ApiKey = config.GetValue<string>("Cloudinary:ApiKey"),
          ApiSecret = config.GetValue<string>("Cloudinary:ApiSecret")
      };*/
