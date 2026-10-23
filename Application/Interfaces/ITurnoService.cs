using Application.Models;

namespace Application.Interfaces;

public interface ITurnoService
{
    List<TurnoDto> GetAll();
    TurnoDto? GetById(int id);
    List<TurnoDto> GetByDoctorId(int doctorId);
    List<TurnoDto> GetByPatientId(int patientId);
    TurnoDto Create(CreateTurnoDto dto);
    bool Cancel(int id);
}
