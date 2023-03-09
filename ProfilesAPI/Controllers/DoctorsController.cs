using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Controllers;

[ApiController]
[Route("api/doctors")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorsService _service;

    public DoctorsController(IDoctorsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDto dto)
    {
        var paginatedDoctors = await _service.GetAllAsync(dto, HttpContext.RequestAborted);

        return Ok(paginatedDoctors);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var doctor = await _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (doctor == null)
        {
            return BadRequest($"Doctor with Id = {id} not found");
        }

        return Ok(doctor);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorsByOfficeId([FromRoute] Guid id)
    {
        var doctors = await _service.GetDoctorsByOfficeIdAsync(id, HttpContext.RequestAborted);
        if (doctors == null)
        {
            return BadRequest($"No doctors related to office with Id = {id}");
        }

        return Ok(doctors);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorsBySpecializationId([FromRoute] Guid id)
    {
        var doctors = await _service.GetDoctorsBySpecializationIdAsync(id, HttpContext.RequestAborted);
        if (doctors == null)
        {
            return BadRequest($"No doctors related to specialization with Id = {id}");
        }

        return Ok(doctors);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DoctorDto dto)
    {
        await _service.CreateAsync(dto, HttpContext.RequestAborted);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DoctorDto dto)
    {
        var existingDoctor = await _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (existingDoctor == null)
        {
            return BadRequest($"Doctor with Id = {id} not found");
        }

        await _service.UpdateAsync(dto, HttpContext.RequestAborted);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var existingDoctor = _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (existingDoctor == null)
        {
            return BadRequest($"Doctor with Id = {id} not found");
        }

        await _service.DeleteAsync(id, HttpContext.RequestAborted);

        return Ok();
    }
}