using System.Text.Json.Serialization;
using Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(
        options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        }
    );

// Add CORS
builder.Services.AddCorsService();
// Add Swagger services
builder.Services.AddSwaggerService();
// Add Auth servicds
builder.Services.AddAuthService(builder.Configuration);
// Add Database services
builder.Services.AddDatabaseService(builder.Configuration);
// Add Application repository
builder.Services.AddApplicationRepository();
// Add Application services
builder.Services.AddApplicationService();
// Add Fluent validation
builder.Services.AddFluentValidator();

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
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseCors("AllowGoogleAuth");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
