using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.DTOs.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        [Route("get-models")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _modelService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var model = await _modelService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ModelForCreateDto modelForCreateDto)
        {
            await _modelService.CreateAsync(modelForCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ModelForUpdateDto modelForUpdateDto)
        {
            await _modelService.UpdateAsync(modelForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _modelService.DeleteAsync(id);

            return NoContent();
        }
    }
}
