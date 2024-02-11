using Microsoft.AspNetCore.Http;

namespace FW.Application
{
    public interface  IFileUploader
    {
        string Upload(IFormFile file, string path);
    }
}
