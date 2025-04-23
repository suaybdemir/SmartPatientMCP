namespace SmartPatientMCP;
public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string FullName => $"{Name} {Surname}";
    public byte Gender { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
    public ICollection<MedicalRecord>? MedicalRecords { get; set; } 

}
