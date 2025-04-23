using SmartPatientMCP.DbContextNamespace;
using Microsoft.EntityFrameworkCore;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace SmartPatientMCP.Tools;

[McpServerToolType]
public class MedicalRecordTool
{
    private readonly AppDbContext _context;

    public MedicalRecordTool(AppDbContext context)
    {
        _context = context;
    }

    [McpServerTool, Description("Retrieves all medical records from the database.")]
    public async Task<List<MedicalRecord>> GetAllMedicalRecordsAsync()
    {
        return await _context.MedicalRecords.ToListAsync();
    }

    [McpServerTool, Description("Retrieves a medical record by its ID.")]
    public async Task<MedicalRecord?> GetMedicalRecordByIdAsync(int id)
    {
        return await _context.MedicalRecords.FindAsync(id);
    }

    [McpServerTool, Description("Adds a new medical record to the database.")]
    public async Task AddMedicalRecordAsync(MedicalRecord medicalRecord)
    {
        _context.MedicalRecords.Add(medicalRecord);
        await _context.SaveChangesAsync();
    }

    [McpServerTool, Description("Updates an existing medical record in the database.")]
    public async Task UpdateMedicalRecordAsync(MedicalRecord medicalRecord)
    {
        _context.MedicalRecords.Update(medicalRecord);
        await _context.SaveChangesAsync();
    }

    [McpServerTool, Description("Deletes a medical record by its ID.")]
    public async Task DeleteMedicalRecordAsync(int id)
    {
        var medicalRecord = await _context.MedicalRecords.FindAsync(id);
        if (medicalRecord != null)
        {
            _context.MedicalRecords.Remove(medicalRecord);
            await _context.SaveChangesAsync();
        }
    }
}
