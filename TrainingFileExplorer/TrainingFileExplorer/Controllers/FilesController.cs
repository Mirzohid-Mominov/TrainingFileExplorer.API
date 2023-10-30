using Microsoft.AspNetCore.Mvc;
using TrainingFileExplorer.Aplication.FileStorage.Models.Filtering;
using TrainingFileExplorer.Aplication.FileStorage.Services;

namespace TrainingFileExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IFileProcessingService _fileProcessingService;

        public FilesController(IWebHostEnvironment hostEnvironment, IFileProcessingService fileProcessingService)
        {
            _hostEnvironment = hostEnvironment;
            _fileProcessingService = fileProcessingService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetFilesAsync([FromServices] StorageFileFilterModel filterModel)
        {
            var files = await _fileProcessingService.GetFilterAsync(filterModel);

            return files.Any() ? Ok(files) : NotFound(files);
        }
    }
}
