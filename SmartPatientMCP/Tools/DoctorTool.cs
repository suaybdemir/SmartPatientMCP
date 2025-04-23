using SmartPatientMCP.DbContextNamespace;
using Microsoft.EntityFrameworkCore;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace SmartPatientMCP.Tools;

[McpServerToolType]
public class DoctorTool
{
    private readonly AppDbContext _context;

    public DoctorTool(AppDbContext context)
    {
        _context = context;
    }

    [McpServerTool, Description("Retrieves all doctors from the database.")]
    public async Task<List<Doctor>> GetAllDoctorsAsync()
    {
        return await _context.Doctors.ToListAsync();
    }

    [McpServerTool, Description("Retrieves a doctor by their ID.")]
    public async Task<Doctor?> GetDoctorByIdAsync(int id)
    {
        return await _context.Doctors.FindAsync(id);
    }

    [McpServerTool, Description("Adds a new doctor to the database.")]
    public async Task AddDoctorAsync(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
    }

    [McpServerTool, Description("Updates an existing doctor in the database.")]
    public async Task UpdateDoctorAsync(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
    }

    [McpServerTool, Description("Deletes a doctor by their ID.")]
    public async Task DeleteDoctorAsync(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
