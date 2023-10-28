using ComputerStore.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivesController : ControllerBase
    {
        private readonly IDriveService _driveService;

        public DrivesController(IDriveService driveService)
        {
            _driveService = driveService;
        }

        [HttpGet]
        [Route("get-drives")]
        public async Task<IActionResult> GetAllAsync()
        {
            var status = await _driveService.GetAllAsync();

            return Ok(status);
        }

        [HttpGet("get-drive/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var gpu = await _driveService.GetByIdAsync(id);

            if (gpu == null)
                return NotFound();

            return Ok(gpu);
        }
    }
}