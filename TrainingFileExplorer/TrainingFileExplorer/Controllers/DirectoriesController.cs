using Microsoft.AspNetCore.Mvc;
using TrainingFileExplorer.Aplication.FileStorage.Services;
using TrainingFileExplorer.Infrastructure.FileStorage.Services;

namespace TrainingFileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectoriesController : ControllerBase
{
    private readonly IDirectoryProcessingService _directoryProcessingService;

    public DirectoriesController(IDirectoryProcessingService directoryProcessingService)
    {
        _directoryProcessingService = directoryProcessingService;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetRootEntriesAsync([FromServices] IWebHostEnvironment webHostEnvironment)
    {
        return Ok(await _directoryProcessingService.GetEntriesAsync(webHostEnvironment.WebRootPath));
    }
}
