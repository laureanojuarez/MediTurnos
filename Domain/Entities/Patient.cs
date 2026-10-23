using System;

namespace Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Dni { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string ObraSocial { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
