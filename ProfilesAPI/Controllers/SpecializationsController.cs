using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecializationsController : ControllerBase
{
    private readonly ISpecializationsService _service;

    public SpecializationsController(ISpecializationsService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SpecializationDto dto)
    {
        await _service.CreateAsync(dto, HttpContext.RequestAborted);

        return Ok();
    }
}