using WebApiPerformanceUploadFiles.Interface;
using static System.Net.Mime.MediaTypeNames;

using System.Buffers.Text;

namespace WebApiPerformanceUploadFiles.Services
{
    public class FileService : IFileService
    {
        public Stream GetImageAsStream()
        {
            var stream = new MemoryStream(Convert.FromBase64String(Image.Base64Image));

            return stream;
        }

        public byte[] GetImageAsByteArray()
        {
            var bytes = Convert.FromBase64String(Image.Base64Image);

            return bytes;
        }
    }
}
