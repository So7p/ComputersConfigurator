using ComputerStore.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerTypesController : ControllerBase
    {
        private readonly IComputerTypeService _computerTypeService;

        public ComputerTypesController(IComputerTypeService computerTypeService)
        {
            _computerTypeService = computerTypeService;
        }

        [HttpGet]
        [Route("get-computerTypes")]
        public async Task<IActionResult> GetAllAsync()
        {
            var status = await _computerTypeService.GetAllAsync();

            return Ok(status);
        }

        [HttpGet("get-computerType/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var computerType = await _computerTypeService.GetByIdAsync(id);

            if (computerType == null)
                return NotFound();

            return Ok(computerType);
        }
    }
}