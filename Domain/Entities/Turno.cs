using System;
using Domain.Enum;

namespace Domain.Entities;


public class Turno
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime Date { get; set; }
    public Status Status { get; set; }
    public Doctor? Doctor { get; set; }
    public Patient? Patient { get; set; }
}
