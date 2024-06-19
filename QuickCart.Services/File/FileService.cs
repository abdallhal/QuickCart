
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace QuickCart.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private  readonly string _rootPath;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _rootPath= _webHostEnvironment.WebRootPath; 
        }

        public List<string> CreateRange(List<IFormFile> files)
        {
            var filesName = new List<string>(); 
            if(files!=null&& files.Any())
            {
               

                var uploadDirectory  = Path.Combine(_rootPath, @"Images/Products");
                Directory.CreateDirectory(uploadDirectory );

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        var filePath = Path.Combine(uploadDirectory , fileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            filesName.Add(fileName);
                        }

                    }
                }
                return filesName;
            }
            return filesName;
       
         
        }

        public void RemoveFiles(List<string> fileNames)
        {
            var uploadDirectory = Path.Combine(_rootPath, @"Images/Products");

            foreach (var fileName in fileNames)
            {
                var filePath = Path.Combine(uploadDirectory, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        public List<string> GetFiles(List<string> fileNames)
        {
            var result = new List<string>();
            var uploadDirectory = Path.Combine(_rootPath, @"Images/Products");

            foreach (var fileName in fileNames)
            {
                var filePath = Path.Combine(uploadDirectory, fileName);
                if (File.Exists(filePath))
                {
                    result.Add(filePath);
                }
            }
            return result;
        }
    }
}
