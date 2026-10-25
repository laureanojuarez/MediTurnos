using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurnosController : ControllerBase
{
    private readonly ITurnoService _turnoService;

    public TurnosController(ITurnoService turnoService)
    {
        _turnoService = turnoService;
    }

    [HttpGet]
    public ActionResult<List<TurnoDto>> GetAll()
    {
        var turnos = _turnoService.GetAll();
        return Ok(turnos);
    }

    [HttpGet("{id:int}")]
    public ActionResult<TurnoDto> GetById(int id)
    {
        var turno = _turnoService.GetById(id);
        if (turno is null)
        {
            return NotFound(new { message = $"No se encontró el turno con ID {id}." });
        }
        return Ok(turno);
    }

    [HttpGet("doctor/{doctorId:int}")]
    public ActionResult<List<TurnoDto>> GetByDoctor(int doctorId)
    {
        var turnos = _turnoService.GetByDoctorId(doctorId);
        return Ok(turnos);
    }

    [HttpGet("patient/{patientId:int}")]
    public ActionResult<List<TurnoDto>> GetByPatient(int patientId)
    {
        var turnos = _turnoService.GetByPatientId(patientId);
        return Ok(turnos);
    }

    [HttpPost]
    public ActionResult<TurnoDto> Create([FromBody] CreateTurnoDto dto)
    {
        try
        {
            var created = _turnoService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:int}/cancel")]
    public IActionResult Cancel(int id)
    {
        var success = _turnoService.Cancel(id);
        if (!success)
        {
            return NotFound(new { message = $"No se encontró el turno con ID {id}." });
        }
        return NoContent();
    }
}
