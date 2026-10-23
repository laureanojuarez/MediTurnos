using Domain.Entities;

namespace Domain.Interfaces;

public interface IDoctorRepository
{
    List<Doctor> GetAll();
    Doctor? GetById(int id);
    void Add(Doctor doctor);
    void Update(Doctor doctor);
    void Delete(int id);
}
