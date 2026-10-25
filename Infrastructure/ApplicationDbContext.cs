using Domain.Entities;
using Domain.Enum;

namespace Infrastructure;

public class ApplicationDbContext
{
    public List<Doctor> Doctors { get; } =
    [
        new Doctor
        {
            Id = 1,
            Name = "Dra. Carolina Rossi",
            Specialty = "Cardiología",
            Matricula = "MN-12345",
            Email = "carolina.rossi@mediturnos.com"
        },
        new Doctor
        {
            Id = 2,
            Name = "Dr. Martín Gómez",
            Specialty = "Pediatría",
            Matricula = "MN-67890",
            Email = "martin.gomez@mediturnos.com"
        },
        new Doctor
        {
            Id = 3,
            Name = "Dra. Lucía Fernández",
            Specialty = "Dermatología",
            Matricula = "MN-45678",
            Email = "lucia.fernandez@mediturnos.com"
        }
    ];

    public List<Patient> Patients { get; } =
    [
        new Patient
        {
            Id = 1,
            Name = "Juan",
            LastName = "Pérez",
            Dni = 35123456,
            PhoneNumber = "+5491144556677",
            ObraSocial = "OSDE",
            Email = "juan.perez@example.com"
        },
        new Patient
        {
            Id = 2,
            Name = "María",
            LastName = "González",
            Dni = 40987654,
            PhoneNumber = "+5491188990011",
            ObraSocial = "Swiss Medical",
            Email = "maria.gonzalez@example.com"
        }
    ];

    public List<Turno> Turnos { get; } = [];
}
