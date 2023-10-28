using ComputerStore.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerBrandsController : ControllerBase
    {
        private readonly IComputerBrandService _computerBrandService;

        public ComputerBrandsController(IComputerBrandService computerBrandService)
        {
            _computerBrandService = computerBrandService;
        }

        [HttpGet]
        [Route("get-computerBrands")]
        public async Task<IActionResult> GetAllAsync()
        {
            var status = await _computerBrandService.GetAllAsync();

            return Ok(status);
        }

        [HttpGet("get-computerBrand/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var computerBrand = await _computerBrandService.GetByIdAsync(id);

            if (computerBrand == null)
                return NotFound();

            return Ok(computerBrand);
        }
    }
}