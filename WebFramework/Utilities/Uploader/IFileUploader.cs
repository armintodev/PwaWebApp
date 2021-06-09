using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebFramework.Utilities.Uploader
{
    public interface IFileUploader
    {
        public Task<string> Upload(IFormFile file, string path);
        public void Delete(string fileName);
    }
}
