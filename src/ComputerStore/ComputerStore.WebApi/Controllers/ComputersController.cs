using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.DTOs.Computer;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputersController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        [Route("get-computers")]
        public async Task<IActionResult> GetAllAsync()
        {
            var status = await _computerService.GetAllAsync();

            return Ok(status);
        }

        [HttpGet("get-computer/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var computer = await _computerService.GetByIdAsync(id);

            if (computer == null)
                return NotFound();

            return Ok(computer);
        }

        [HttpPost]
        [Route("create-computer")]
        public async Task<IActionResult> CreateAsync([FromBody] ComputerForCreateDto computerForCreateDto)
        {
            await _computerService.CreateAsync(computerForCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        [Route("update-computer")]
        public async Task<IActionResult> UpdateAsync([FromBody] ComputerForUpdateDto computerForUpdateDto)
        {
            await _computerService.UpdateAsync(computerForUpdateDto);

            return NoContent();
        }

        [HttpDelete("delete-computer/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _computerService.DeleteAsync(id);

            return Ok(); //NoContent();
        }
    }
}