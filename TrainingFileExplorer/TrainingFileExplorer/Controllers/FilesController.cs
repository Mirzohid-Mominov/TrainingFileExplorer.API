using Microsoft.AspNetCore.Mvc;
using TrainingFileExplorer.Application.FileStorage.Models.Filtering;
using TrainingFileExplorer.Application.FileStorage.Services;

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

        [HttpGet("root/files/filter")]
        public async ValueTask<IActionResult> GetFilesSummaryAsync()
        {
            var data = await _fileProcessingService.GetFilterDataModelAsync(_hostEnvironment.WebRootPath);
            return Ok(data);
        }


        [HttpGet("root/files/by-filter")]
        public async ValueTask<IActionResult> GetFilesAsync([FromQuery] StorageFileFilterModel filterModel)
        {
            filterModel.DirectoryPath = _hostEnvironment.WebRootPath;

            var files = await _fileProcessingService.GetByFilterAsync(filterModel);

            return files.Any() ? Ok(files) : NotFound(files);
        }

    }
}
