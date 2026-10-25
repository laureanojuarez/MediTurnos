using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _context;

    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Doctor> GetAll()
    {
        return _context.Doctors.ToList();
    }

    public Doctor? GetById(int id)
    {
        return _context.Doctors.FirstOrDefault(d => d.Id == id);
    }

    public void Add(Doctor doctor)
    {
        doctor.Id = _context.Doctors.Count > 0 ? _context.Doctors.Max(d => d.Id) + 1 : 1;
        _context.Doctors.Add(doctor);
    }

    public void Update(Doctor doctor)
    {
        var existing = GetById(doctor.Id);
        if (existing is null) return;

        existing.Name = doctor.Name;
        existing.Specialty = doctor.Specialty;
        existing.Matricula = doctor.Matricula;
        existing.Email = doctor.Email;
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing is not null)
        {
            _context.Doctors.Remove(existing);
        }
    }
}
