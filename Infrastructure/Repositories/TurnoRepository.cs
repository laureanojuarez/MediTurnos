using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class TurnoRepository : ITurnoRepository
{
    private readonly ApplicationDbContext _context;

    public TurnoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Turno> GetAll()
    {
        return _context.Turnos.ToList();
    }

    public Turno? GetById(int id)
    {
        return _context.Turnos.FirstOrDefault(t => t.Id == id);
    }

    public List<Turno> GetByDoctorId(int doctorId)
    {
        return _context.Turnos.Where(t => t.DoctorId == doctorId).ToList();
    }

    public List<Turno> GetByPatientId(int patientId)
    {
        return _context.Turnos.Where(t => t.PatientId == patientId).ToList();
    }

    public void Add(Turno turno)
    {
        turno.Id = _context.Turnos.Count > 0 ? _context.Turnos.Max(t => t.Id) + 1 : 1;
        _context.Turnos.Add(turno);
    }

    public void Update(Turno turno)
    {
        var existing = GetById(turno.Id);
        if (existing is null) return;

        existing.DoctorId = turno.DoctorId;
        existing.PatientId = turno.PatientId;
        existing.Date = turno.Date;
        existing.Status = turno.Status;
        existing.Doctor = turno.Doctor;
        existing.Patient = turno.Patient;
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing is not null)
        {
            _context.Turnos.Remove(existing);
        }
    }
}
