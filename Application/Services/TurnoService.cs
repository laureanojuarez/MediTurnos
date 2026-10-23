using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;

namespace Application.Services;

public class TurnoService : ITurnoService
{
    private readonly ITurnoRepository _turnoRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;

    public TurnoService(
        ITurnoRepository turnoRepository,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository)
    {
        _turnoRepository = turnoRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
    }

    public List<TurnoDto> GetAll()
    {
        var turnos = _turnoRepository.GetAll();
        return turnos.Select(MapToDto).ToList();
    }

    public TurnoDto? GetById(int id)
    {
        var turno = _turnoRepository.GetById(id);
        return turno is null ? null : MapToDto(turno);
    }

    public List<TurnoDto> GetByDoctorId(int doctorId)
    {
        var turnos = _turnoRepository.GetByDoctorId(doctorId);
        return turnos.Select(MapToDto).ToList();
    }

    public List<TurnoDto> GetByPatientId(int patientId)
    {
        var turnos = _turnoRepository.GetByPatientId(patientId);
        return turnos.Select(MapToDto).ToList();
    }

    public TurnoDto Create(CreateTurnoDto dto)
    {
        // 1. Validar que el médico exista
        var doctor = _doctorRepository.GetById(dto.DoctorId)
            ?? throw new InvalidOperationException($"El médico con ID {dto.DoctorId} no existe.");

        // 2. Validar que el paciente exista
        var patient = _patientRepository.GetById(dto.PatientId)
            ?? throw new InvalidOperationException($"El paciente con ID {dto.PatientId} no existe.");

        // 3. Validar que la fecha sea en el futuro
        if (dto.Date <= DateTime.Now)
        {
            throw new InvalidOperationException("La fecha del turno debe ser posterior al momento actual.");
        }

        // 4. Validar disponibilidad del médico
        var existingDoctorTurnos = _turnoRepository.GetByDoctorId(dto.DoctorId);
        bool hasConflict = existingDoctorTurnos.Any(t =>
            t.Status != Status.Cancelled &&
            t.Date == dto.Date);

        if (hasConflict)
        {
            throw new InvalidOperationException("El médico ya tiene un turno agendado en ese horario.");
        }

        // 5. Crear y persistir el turno
        var turno = new Turno
        {
            DoctorId = dto.DoctorId,
            PatientId = dto.PatientId,
            Date = dto.Date,
            Status = Status.Pending
        };

        _turnoRepository.Add(turno);

        // Asociar las referencias para armar la respuesta completa
        turno.Doctor = doctor;
        turno.Patient = patient;

        return MapToDto(turno);
    }

    public bool Cancel(int id)
    {
        var turno = _turnoRepository.GetById(id);
        if (turno is null)
        {
            return false;
        }

        turno.Status = Status.Cancelled;
        _turnoRepository.Update(turno);
        return true;
    }

    private TurnoDto MapToDto(Turno turno)
    {
        var doctor = turno.Doctor ?? _doctorRepository.GetById(turno.DoctorId);
        var patient = turno.Patient ?? _patientRepository.GetById(turno.PatientId);

        return new TurnoDto
        {
            Id = turno.Id,
            DoctorId = turno.DoctorId,
            DoctorName = doctor != null ? doctor.Name : string.Empty,
            PatientId = turno.PatientId,
            PatientName = patient != null ? $"{patient.Name} {patient.LastName}" : string.Empty,
            Date = turno.Date,
            Status = turno.Status
        };
    }
}
