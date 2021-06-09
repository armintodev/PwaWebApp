using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebFramework.Infrastructure;

namespace WebFramework.Utilities.Uploader
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHost;
        public FileUploader(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public async Task<string> Upload(IFormFile file, string path)
        {
            if (file is null) return "";

            //for example: Photos//Developer//fileName
            var directoryPath = $"{_webHost.WebRootPath}//lib//Photos//{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";
            await using var output = File.Create(filePath);
            await file.CopyToAsync(output);
            return $"{path}/{fileName}";
        }

        public void Delete(string fileName)
        {
            var directoryPath = $"{_webHost.WebRootPath}//lib//Photos//";

            var filePath = $"{directoryPath}//{fileName}";

            File.Delete(filePath);
        }
    }
}
