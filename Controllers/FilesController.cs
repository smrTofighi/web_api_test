using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfoApi.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        FileExtensionContentTypeProvider fileExtensionContentTypeProvider;
        FilesController(FileExtensionContentTypeProvider fileExtensionContentType)
        {
            fileExtensionContentTypeProvider = fileExtensionContentType;
        }
        [HttpGet]
        public ActionResult GetFile(string fileId)
        {
            string pathToFile = "wallpaper.jpg";
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }
            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            if (!fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType)) {
                contentType = "application/octet-stream";
            }
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
