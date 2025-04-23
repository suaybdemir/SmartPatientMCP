using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using SmartPatientMCP.DbContextNamespace;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(co=>{
    co.LogToStandardErrorThreshold = LogLevel.Trace;
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfConsoleDb;Trusted_Connection=True;")
);


builder.Services
.AddMcpServer()
.WithStdioServerTransport()
.WithToolsFromAssembly();

Console.WriteLine(DateTime.Now);

await builder.Build().RunAsync();

