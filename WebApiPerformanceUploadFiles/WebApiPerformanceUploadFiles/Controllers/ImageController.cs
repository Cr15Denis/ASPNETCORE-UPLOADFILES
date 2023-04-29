using Microsoft.AspNetCore.Mvc;
using WebApiPerformanceUploadFiles.Interface;
using WebApiPerformanceUploadFiles.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPerformanceUploadFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IFileService _fileService;
        private const string MimeType = "image/png";
        private const string FileName = "CM-Logo.png";
        public ImageController(IFileService fileService) 
        {
            _fileService = fileService;
        }

        [HttpGet("images-byte")]
        public IActionResult ReturnByteArray()
        {
            var image = _fileService.GetImageAsByteArray();
            return File(image, MimeType, FileName);
        }

    }
}
