namespace Application.Models;

public class CreateTurnoDto
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime Date { get; set; }
}
