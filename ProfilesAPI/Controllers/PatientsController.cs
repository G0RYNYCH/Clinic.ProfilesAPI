using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientsService _service;

    public PatientsController(IPatientsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDto dto)
    {
        var paginatedPatients = await _service.GetAllAsync(dto, HttpContext.RequestAborted);

        return Ok(paginatedPatients);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var patient = await _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (patient == null)
        {
            return BadRequest($"Patient with Id = {id} not found");
        }

        return Ok(patient);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PatientDto dto)
    {
        await _service.CreateAsync(dto, HttpContext.RequestAborted);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PatientDto dto)
    {
        var existingPatient = await _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (existingPatient == null)
        {
            return BadRequest($"Patient with Id = {id} not found");
        }

        await _service.UpdateAsync(dto, HttpContext.RequestAborted);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var existingPatient = _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (existingPatient == null)
        {
            return BadRequest($"Patient with Id = {id} not found");
        }

        await _service.DeleteAsync(id, HttpContext.RequestAborted);

        return Ok();
    }
}