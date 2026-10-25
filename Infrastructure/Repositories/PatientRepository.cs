using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Patient> GetAll()
    {
        return _context.Patients.ToList();
    }

    public Patient? GetById(int id)
    {
        return _context.Patients.FirstOrDefault(p => p.Id == id);
    }

    public Patient? GetByDni(int dni)
    {
        return _context.Patients.FirstOrDefault(p => p.Dni == dni);
    }

    public void Add(Patient patient)
    {
        patient.Id = _context.Patients.Count > 0 ? _context.Patients.Max(p => p.Id) + 1 : 1;
        _context.Patients.Add(patient);
    }

    public void Update(Patient patient)
    {
        var existing = GetById(patient.Id);
        if (existing is null) return;

        existing.Name = patient.Name;
        existing.LastName = patient.LastName;
        existing.Dni = patient.Dni;
        existing.PhoneNumber = patient.PhoneNumber;
        existing.ObraSocial = patient.ObraSocial;
        existing.Email = patient.Email;
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing is not null)
        {
            _context.Patients.Remove(existing);
        }
    }
}
