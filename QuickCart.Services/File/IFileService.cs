
using Microsoft.AspNetCore.Http;

namespace QuickCart.Services
{
    public interface IFileService
    {
        List<string> CreateRange(List<IFormFile> files);
        List<string> GetFiles(List<string> fileNames);
        void RemoveFiles(List<string> fileNames);
    }
}
