using Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add Swagger services
builder.Services.AddSwaggerService();
// Add Database services
builder.Services.AddDatabaseService(builder.Configuration);
// Add Application services
builder.Services.AddApplicationService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        (options) =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1.0");
            options.RoutePrefix = string.Empty;
        }
    );
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
