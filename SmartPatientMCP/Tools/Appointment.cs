using System;
using SmartPatientMCP.DbContextNamespace;
using Microsoft.EntityFrameworkCore;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace SmartPatientMCP.Tools;

[McpServerToolType]
public class AppointmentTool
{
    private readonly AppDbContext _context;

    public AppointmentTool(AppDbContext context)
    {
        _context = context;
    }

    [McpServerTool, Description("Retrieves all appointments from the database.")]
    public async Task<List<Appointment>> GetAllAppointmentsAsync()
    {
        return await _context.Appointments.ToListAsync();
    }

    [McpServerTool, Description("Retrieves an appointment by its ID.")]
    public async Task<Appointment?> GetAppointmentByIdAsync(int id)
    {
        return await _context.Appointments.FindAsync(id);
    }

    [McpServerTool, Description("Adds a new appointment to the database.")]
    public async Task AddAppointmentAsync(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
    }

    [McpServerTool, Description("Updates an existing appointment in the database.")]
    public async Task UpdateAppointmentAsync(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
    }

    [McpServerTool, Description("Deletes an appointment by its ID.")]
    public async Task DeleteAppointmentAsync(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment != null)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
