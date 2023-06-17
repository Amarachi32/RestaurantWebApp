using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Implementation;

namespace RestaurantWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly ImageUploadService _imageUploadService;

        public ImageController(ImageUploadService imageUploadService)
        {
            _imageUploadService = imageUploadService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if (imageFile == null)
            {
                return BadRequest("No image file uploaded.");
            }

            var imageUrl = await _imageUploadService.UploadImageAsync(imageFile);

            return Ok(imageUrl);
        }
        /* private readonly CloudinaryService _cloudinaryService;

               public ImageController()
               {
                   _cloudinaryService = new CloudinaryService();
               }

               [HttpPost]
               public IActionResult UploadImage()
               {
                   if (!Request.Content.IsMimeMultipartContent())
                   {
                       return BadRequest("Unsupported media type");
                   }

                   var file = HttpContext.Current.Request.Files[0];

                   if (file != null && file.ContentLength > 0)
                   {
                       var imagePath = Path.GetTempFileName(); // Or use your desired image path
                       file.SaveAs(imagePath);

                       var result = _cloudinaryService.UploadImage(imagePath);

                       // Handle the result, e.g., return the public URL of the uploaded image
                       var imageUrl = result.SecureUri.AbsoluteUri;

                       return Ok(imageUrl);
                   }

                   return BadRequest("No file uploaded");
               }
           }*/




        /*        public static IWebHostEnvironment _enviroment;
                public ImageController(IWebHostEnvironment enviroment)
                {
                    _enviroment= enviroment;
                }

                public class FileUploadApi
                {
                    public IFormFile file { get; set;}
                }
                [HttpPost]
                public async Task<string> Post(FileUploadApi fileUpload)
                {
                    try
                    {
                        if (fileUpload.file.Length > 0)
                        {
                            if (!Directory.Exists(_enviroment.WebRootPath + "\\upload\\"))
                            {
                                Directory.CreateDirectory(_enviroment.WebRootPath + "\\upload\\");
                            }
                            using (FileStream fileStream = System.IO.File.Create(_enviroment.WebRootPath + "\\upload\\"))
                            {
                                fileUpload.file.CopyTo(fileStream);
                                fileStream.Flush();
                                return "\\upload\\" + fileUpload.file.FileName;
                            }
                        }
                        else
                        {
                            return "failed";
                        }

                    }catch (Exception ex) { 
                        return ex.Message.ToString();
                    }
                }

        */

    }
}