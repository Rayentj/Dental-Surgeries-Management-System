using DentalApp.Application.Services.Interfaces;
using DentalApp.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace DentalApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurgeryController : ControllerBase
    {
        private readonly ISurgeryService _service;
        public SurgeryController(ISurgeryService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Surgery surgery)
        {
            var created = await _service.CreateAsync(surgery);
            return CreatedAtAction(nameof(GetById), new { id = created.SurgeryId }, created);
        }
    }

}
