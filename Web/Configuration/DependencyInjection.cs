using System.Reflection;
using Application.Interfaces;
using Application.Services;
using Application.Services.SkillGroup;
using Application.Services.CourseGroup;
using Application.Services.Interfaces;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.GenericRepository;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Domain.Entities.RoleGroup;
using Domain.Entities.UserGroup;

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

                options.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "BearerAuth"
                            }
                        },
                        []
                    }
                });
            }
        );

        return services;
    }

    // Auth
    public static IServiceCollection AddAuthService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddIdentityApiEndpoints<User>(options =>
        {
            options.SignIn.RequireConfirmedEmail = true;
            options.User.RequireUniqueEmail = true;
        })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<DatabaseContext>();

        services.AddAuthentication()
        .AddGoogle(options =>
        {
            options.SignInScheme = IdentityConstants.ExternalScheme;
            options.ClientId = configuration["Authentication:Google:ClientId"]!;
            options.ClientSecret = configuration["Authentication:Google:ClientSecret"]!;
            options.CallbackPath = new PathString("/signin-google");
        });

        return services;
    }

    // Fluent Validator
    public static IServiceCollection AddFluentValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
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
        services.AddScoped<IQualityRepository, QualityRepository>();
        services.AddScoped<IFormatRepository, FormatRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IEbookRepository, EbookRepository>();
        services.AddScoped<IVideoRepository, VideoRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserCourseRepository, UserCourseRepository>();
        services.AddScoped<IUserSkillRepository, UserSkillRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();

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
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}
