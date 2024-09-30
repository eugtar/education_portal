using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data;

public class SampleContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder();

        builder.SetFileLoadExceptionHandler((error) => Console.WriteLine(error.Exception.Message));
        builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
        builder.AddJsonFile("appsettings.json");

        var config = builder.Build();

        var connectionString = config.GetConnectionString("DefaultConnection");
        
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Trace);
        optionsBuilder.UseSqlServer(connectionString);
        
        return new DatabaseContext(optionsBuilder.Options);
    }
}
