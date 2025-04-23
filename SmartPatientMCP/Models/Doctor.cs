using System;

namespace SmartPatientMCP;

public class Doctor {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public ICollection<Appointment>? Appointments { get; set; }
}
