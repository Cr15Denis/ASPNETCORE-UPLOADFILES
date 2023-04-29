namespace WebApiPerformanceUploadFiles.Interface
{
    public interface IFileService
    {
        Stream GetImageAsStream();
        byte[] GetImageAsByteArray();
    }
}
