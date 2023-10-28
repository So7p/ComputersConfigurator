using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.DTOs.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationsController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        [Route("get-configurations")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _configurationService.GetAllAsync());
        }

        [HttpGet("get-configuration/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var configuration = await _configurationService.GetByIdAsync(id);

            if (configuration == null)
                return NotFound();

            return Ok(configuration);
        }

        [HttpPost]
        [Route("create-configuration")]
        public async Task<IActionResult> CreateAsync([FromBody] ConfigurationForCreateDto configurationForCreateDto)
        {
            await _configurationService.CreateAsync(configurationForCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        [Route("update-configuration")]
        public async Task<IActionResult> UpdateAsync([FromBody] ConfigurationForUpdateDto configurationForUpdateDto)
        {
            await _configurationService.UpdateAsync(configurationForUpdateDto);

            return NoContent();
        }

        [HttpDelete("delete-configuration/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _configurationService.DeleteAsync(id);

            return Ok();
        }
    }
}
