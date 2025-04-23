using SmartPatientMCP.DbContextNamespace;
using Microsoft.EntityFrameworkCore;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace SmartPatientMCP.Tools;

[McpServerToolType]
public class PatientTool
{
    private readonly AppDbContext _context;

    public PatientTool(AppDbContext context)
    {
        _context = context;
    }

    [McpServerTool, Description("Retrieves all patients from the database.")]
    public async Task<List<Patient>> GetAllPatientsAsync()
    {
        return await _context.Patients.ToListAsync();
    }

    [McpServerTool, Description("Retrieves a patient by their ID.")]
    public async Task<Patient?> GetPatientByIdAsync(int id)
    {
        return await _context.Patients.FindAsync(id);
    }

    [McpServerTool, Description("Adds a new patient to the database.")]
    public async Task AddPatientAsync(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }

    [McpServerTool, Description("Updates an existing patient in the database.")]
    public async Task UpdatePatientAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    [McpServerTool, Description("Deletes a patient by their ID.")]
    public async Task DeletePatientAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}
