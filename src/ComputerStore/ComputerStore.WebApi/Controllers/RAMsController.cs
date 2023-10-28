using ComputerStore.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RAMsController : ControllerBase
    {
        private readonly IRAMService _ramService;

        public RAMsController(IRAMService ramService)
        {
            _ramService = ramService;
        }

        [HttpGet]
        [Route("get-RAMs")]
        public async Task<IActionResult> GetAllAsync()
        {
            var status = await _ramService.GetAllAsync();

            return Ok(status);
        }

        [HttpGet("get-RAM/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var ram = await _ramService.GetByIdAsync(id);

            if (ram == null)
                return NotFound();

            return Ok(ram);
        }
    }
}