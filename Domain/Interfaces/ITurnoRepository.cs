using Domain.Entities;

namespace Domain.Interfaces;

public interface ITurnoRepository
{
    List<Turno> GetAll();
    Turno? GetById(int id);
    List<Turno> GetByDoctorId(int doctorId);
    List<Turno> GetByPatientId(int patientId);
    void Add(Turno turno);
    void Update(Turno turno);
    void Delete(int id);
}
