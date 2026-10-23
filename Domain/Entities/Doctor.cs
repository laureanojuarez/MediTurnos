using System;

namespace Domain.Entities;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
