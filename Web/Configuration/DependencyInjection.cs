using Application.Interfaces;
using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.GenericRepository;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Web.Configuration;

public static class DependencyInjection
{
    // Swagger
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1.0",
                    Title = "Education Portal API",
                });
            }
        );

        return services;
    }

    // Database
    public static IServiceCollection AddDatabaseService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<DatabaseContext>(
            options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            }
        );

        return services;
    }

    // Application Repository
    public static IServiceCollection AddApplicationRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IEbookRepository, EbookRepository>();
        services.AddScoped<IVideoRepository, VideoRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IQualityRepository, QualityRepository>();
        services.AddScoped<IFormatRepository, FormatRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserCourseRepository, UserCourseRepository>();
        services.AddScoped<IUserSkillRepository, UserSkillRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    // Application Services
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IEbookService, EBookService>();
        services.AddScoped<IVideoService, VideoService>();
        services.AddScoped<ISkillService, SkillService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserCourseService, UserCourseService>();
        services.AddScoped<IUserSkillService, UserSkillService>();

        return services;
    }
}
