using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;
using TrainingFileExplorer.Aplication.FileStorage.Services;

namespace TrainingFileExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrivesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public DrivesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync([FromServices] IDriveService driveService)
        {
            var data = await driveService.GetAsync();
            var result = _mapper.Map<IEnumerable<StorageDrive>>(data);  

            return result.Any() ? Ok(result) : NoContent();
        }
    }
}
