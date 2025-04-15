using DentalApp.Application.Services.Interfaces;
using DentalApp.Domain.DTOs.Response;
using DentalApp.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace DentalApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;
        public AddressController(IAddressService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressResponseDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressResponseDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AddressResponseDto>> Create([FromBody] Address address)
        {
            var created = await _service.CreateAsync(address);
            return CreatedAtAction(nameof(GetById), new { id = created.AddressId }, created);
        }
    }
}
