using ComputerStore.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPUsController : ControllerBase
    {
        private readonly ICPUService _cpuService;

        public CPUsController(ICPUService cpuService)
        {
            _cpuService = cpuService;
        }

        [HttpGet]
        [Route("get-CPUs")]
        public async Task<IActionResult> GetAllAsync()
        {
            var status = await _cpuService.GetAllAsync();

            return Ok(status);
        }

        [HttpGet("get-CPU/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var cpu = await _cpuService.GetByIdAsync(id);

            if (cpu == null)
                return NotFound();

            return Ok(cpu);
        }
    }
}