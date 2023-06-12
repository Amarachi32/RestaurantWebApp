using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public static IWebHostEnvironment _enviroment;
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
    }
}
