using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Xml.Linq;
using WebApiPerformanceUploadFiles.Interface;
using WebApiPerformanceUploadFiles.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPerformanceUploadFiles.Controllers
{
    public class UploadMultipartModel
    {
        public IFormFile File { get; set; }
        //public int SomeValue { get; set; }
    }
   
    

    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
       
        // GET: api/<UploadFileController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<UploadFileController> _logger;

     

        private HttpClient _client;
        public UploadFileController(ILogger<UploadFileController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            //_config = config;
            _client = new HttpClient();
            
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadMultipartUsingIFormFile([FromForm] UploadMultipartModel fileUpload)
        {
            
            if (fileUpload.File != null)
            {                       
                var filename = Path.GetFileName(fileUpload.File.FileName);
                var fileextension = Path.GetExtension(filename);
                var newfilename = String.Concat(Convert.ToString(Guid.NewGuid()), fileextension);
                //string filePath = $"{_env.WebRootPath}/images/{newfilename}";
                string filePath = $"D:/PruebasImagenes/{newfilename}";

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    
                        fileUpload.File.CopyTo(stream);
                    
                }
            }

            return Ok();
        }

        //public static async Task<int> ReadStream(Stream stream, int bufferSize)
        //{
        //    var buffer = new byte[bufferSize];

        //    int bytesRead;
        //    int totalBytes = 0;

        //    do
        //    {
        //        bytesRead = await stream.ReadAsync(buffer, 0, bufferSize);
        //        totalBytes += bytesRead;
        //    } while (bytesRead > 0);
        //    return totalBytes;
        //}
        //static string CreateTempfilePath()
        //{
        //    var filename = $"{Guid.NewGuid()}.tmp";
        //    var directoryPath = Path.Combine("temp", "uploads");
        //    if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

        //    return Path.Combine(directoryPath, filename);
        //}

        //[Route("/Page/Image")]
        //public IActionResult GetMovePage(string name)
        //{
        //    //var url = $"/Files/Movies?fileName={fileName}";
        //    //if (string.IsNullOrEmpty(directory) == false)
        //    //{
        //    //    url += $"&directory={directory}";
        //    //}
        //    //ViewData["url"] = url;

        //    //return View("./Views/MoviePage.cshtml");

        //    //ViewData["Greeting"] = "Hello World!";
        //    //return View();
           
        //}

        [HttpGet("display")]
        public async Task<FileStreamResult> Get3()
        {
            var stream = await GetVideoByName("earth");
           
            return new FileStreamResult(stream, "video/mp4");
            
        }

        public async Task<Stream> GetVideoByName(string name)
        {
            var urlBlob = string.Empty;
            switch (name)
            {
                case "earth":
                    urlBlob = "https://anthonygiretti.blob.core.windows.net/videos/earth.mp4";
                    break;
                case "nature1":
                    urlBlob = "https://anthonygiretti.blob.core.windows.net/videos/nature1.mp4";
                    break;
                case "nature2":
                default:
                    urlBlob = "https://anthonygiretti.blob.core.windows.net/videos/nature2.mp4";
                    break;
            }
            return await _client.GetStreamAsync(urlBlob);
        }

        //[ResponseCache(Duration = 600)]
        [Route("Files")]
        [HttpGet]
        public IActionResult GetMovie()
        {
            //string directory = "";
            ////_logger.LogDebug("HelloMovies");
            //var fullPath = Path.Combine("D:/PruebasImagenes", directory);
            //using (var provider = new PhysicalFileProvider(fullPath))
            //{
            //    var stream = provider.GetFileInfo("earth.mp4").CreateReadStream();
            //    return File(stream, "video/mp4");
            //}
             
            //Byte[] b;
           // b = System.IO.File.ReadAllBytes("D:/PruebasImagenes/7df59d50-c2fc-4a53-9dd1-c20c8afec771.png");
            var filePath = Path.Combine($"D:/PruebasImagenes/7df59d50-c2fc-4a53-9dd1-c20c8afec771.png");
            return  PhysicalFile(filePath, "image/jpeg");
            //return File(b, "image/jpeg");
        }

        //[HttpGet("images-byte")]
        //public IActionResult ReturnByteArray()
        //{
        //    var image = _fileService.GetImageAsByteArray();
        //    return File(image, MimeType, FileName);
        //}
    }
}
