using Domain.Entities;

namespace Domain.Interfaces;

public interface IPatientRepository
{
    List<Patient> GetAll();
    Patient? GetById(int id);
    Patient? GetByDni(int dni);
    void Add(Patient patient);
    void Update(Patient patient);
    void Delete(int id);
}
