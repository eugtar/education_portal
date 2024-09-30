using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Presentation;
using Presentation.Uis.Common;

try
{
    var builder = new ConfigurationBuilder();
    
    builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
    builder.AddJsonFile("appsettings.json");

    var config = builder.Build();

    var connectionString = config.GetConnectionString("DefaultConnection");

    var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
    
    optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    optionsBuilder.UseSqlServer(connectionString);

    using (var context = new DatabaseContext(optionsBuilder.Options))
    {
        var app = new App(context);
        app.Init();
    }
}
catch (Exception error)
{
    ConsoleAlert.Result(error.Message, true);
}
