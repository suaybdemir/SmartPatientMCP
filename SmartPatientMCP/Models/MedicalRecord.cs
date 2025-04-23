using System;

namespace SmartPatientMCP;

public class MedicalRecord {
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string Prescription { get; set; } = string.Empty;
    public DateTime RecordDate { get; set; } = DateTime.Now;
}
