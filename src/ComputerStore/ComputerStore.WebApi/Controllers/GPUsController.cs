using ComputerStore.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPUsController : ControllerBase
    {
        private readonly IGPUService _gpuService;

        public GPUsController(IGPUService gpuService)
        {
            _gpuService = gpuService;
        }

        [HttpGet]
        [Route("get-GPUs")]
        public async Task<IActionResult> GetAllAsync()
        {
            var status = await _gpuService.GetAllAsync();

            return Ok(status);
        }

        [HttpGet("get-GPU/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var gpu = await _gpuService.GetByIdAsync(id);

            if (gpu == null)
                return NotFound();

            return Ok(gpu);
        }
    }
}