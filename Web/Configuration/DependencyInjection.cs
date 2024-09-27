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

    // Application
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IArticleRepository, ArticleRepository>();
        services.AddTransient<ICourseRepository, CourseRepository>();
        services.AddTransient<IEbookRepository, EbookRepository>();
        services.AddTransient<IVideoRepository, VideoRepository>();
        services.AddTransient<ISkillRepository, SkillRepository>();
        services.AddTransient<IQualityRepository, QualityRepository>();
        services.AddTransient<IFormatRepository, FormatRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserCourseRepository, UserCourseRepository>();
        services.AddTransient<IUserSkillRepository, UserSkillRepository>();

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        services.AddTransient<IArticleService, ArticleService>();
        services.AddTransient<ICourseService, CourseService>();
        services.AddTransient<IEbookService, EBookService>();
        services.AddTransient<IVideoService, VideoService>();
        services.AddTransient<ISkillService, SkillService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserCourseService, UserCourseService>();
        services.AddTransient<IUserSkillService, UserSkillService>();

        return services;
    }
}
