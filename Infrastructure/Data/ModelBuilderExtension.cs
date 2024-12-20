using Domain.Entities;
using Domain.Entities.RoleGroup;
using Domain.Entities.UserGroup;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // DateTime
        var dateTimeNow = DateTime.UtcNow;

        // Roles
        var role1 = new Role() { Id = 1, Name = "administrator", NormalizedName = "ADMINISTRATOR", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var role2 = new Role() { Id = 2, Name = "teacher", NormalizedName = "TEACHER", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var role3 = new Role() { Id = 3, Name = "student", NormalizedName = "STUDENT", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var role4 = new Role() { Id = 4, Name = "guest", NormalizedName = "GUEST", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // Qualities
        var quality1 = new Quality() { Id = 1, QualityType = "144p", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var quality2 = new Quality() { Id = 2, QualityType = "240p", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var quality3 = new Quality() { Id = 3, QualityType = "360p", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var quality4 = new Quality() { Id = 4, QualityType = "480p", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var quality5 = new Quality() { Id = 5, QualityType = "720p", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var quality6 = new Quality() { Id = 6, QualityType = "1080p", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var quality7 = new Quality() { Id = 7, QualityType = "1440p", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var quality8 = new Quality() { Id = 8, QualityType = "2160p", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // Formats
        var format1 = new Format() { Id = 1, FormatType = "epub", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var format2 = new Format() { Id = 2, FormatType = "pdf", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var format3 = new Format() { Id = 3, FormatType = "docx", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var format4 = new Format() { Id = 4, FormatType = "azw", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var format5 = new Format() { Id = 5, FormatType = "txt", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // User(Administrator)
        /* var hasher = new PasswordHasher<User>();
        var admin = new User
        {
            Id = 1,
            FirstName = "administrator",
            LastName = "administrator",
            UserName = "admin@mail.com",
            NormalizedUserName = "ADMINISTRATOR",
            Email = "admin@mail.com",
            NormalizedEmail = "ADMIN@MAIL.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null!, "Administrator1!"),
            SecurityStamp = string.Empty,
            CreatedAt = dateTimeNow,
            UpdatedAt = dateTimeNow
        };
        var adminRole1 = new UserRole() { RoleId = role1.Id, UserId = admin.Id };
        var adminRole2 = new UserRole() { RoleId = role2.Id, UserId = admin.Id };
        var adminRole3 = new UserRole() { RoleId = role3.Id, UserId = admin.Id };
        var adminRole4 = new UserRole() { RoleId = role4.Id, UserId = admin.Id }; */

        // Articles
        var article1 = new Article() { Id = 1, Title = "js-article(beginner) ", Link = "https://www.w3schools.com/js/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article2 = new Article() { Id = 2, Title = "js-article(intermediate)", Link = "https://www.w3schools.com/js/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article3 = new Article() { Id = 3, Title = "js-article(master)", Link = "https://www.w3schools.com/js/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article4 = new Article() { Id = 4, Title = "react-article(beginner)", Link = "https://www.w3schools.com/react/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article5 = new Article() { Id = 5, Title = "react-article(intermediate)", Link = "https://www.w3schools.com/react/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article6 = new Article() { Id = 6, Title = "react-article(master)", Link = "https://www.w3schools.com/react/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article7 = new Article() { Id = 7, Title = "c#-article(beginner)", Link = "https://www.w3schools.com/cs/index.php", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article8 = new Article() { Id = 8, Title = "c#-article(intermediate)", Link = "https://www.w3schools.com/cs/index.php", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article9 = new Article() { Id = 9, Title = "c#-article(master)", Link = "https://www.w3schools.com/cs/index.php", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // Ebooks
        var ebook1 = new Ebook() { Id = 10, Title = "js-ebook(beginner)", Author = "david flanagan", PageAmount = 1093, PublishedOn = dateTimeNow, FormatId = 2, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook2 = new Ebook() { Id = 11, Title = "js-ebook(intermediate)", Author = "david herman", PageAmount = 228, PublishedOn = dateTimeNow, FormatId = 2, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook3 = new Ebook() { Id = 12, Title = "js-ebook(master)", Author = "nicholas c.zakas", PageAmount = 960, PublishedOn = dateTimeNow, FormatId = 3, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook4 = new Ebook() { Id = 13, Title = "react-ebook(beginner)", Author = "robin wieruch", PageAmount = 286, PublishedOn = dateTimeNow, FormatId = 2, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook5 = new Ebook() { Id = 14, Title = "react-ebook(intermediate)", Author = "adam boduch", PageAmount = 526, PublishedOn = dateTimeNow, FormatId = 3, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook6 = new Ebook() { Id = 15, Title = "react-ebook(master)", Author = "carlos santana roldan", PageAmount = 394, PublishedOn = dateTimeNow, FormatId = 3, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook7 = new Ebook() { Id = 16, Title = "c#-ebook(beginner)", Author = "r.b. whitaker", PageAmount = 406, PublishedOn = dateTimeNow, FormatId = 1, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook8 = new Ebook() { Id = 17, Title = "c#-ebook(intermediate)", Author = "ian griffiths", PageAmount = 778, PublishedOn = dateTimeNow, FormatId = 2, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook9 = new Ebook() { Id = 18, Title = "c#-ebook(master)", Author = "mark j.price", PageAmount = 826, PublishedOn = dateTimeNow, FormatId = 2, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // Videos
        var video1 = new Video() { Id = 19, Title = "js-video(beginner)", Duration = new TimeOnly(1, 30, 25), QualityId = 5, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video2 = new Video() { Id = 20, Title = "js-video(intermediate)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video3 = new Video() { Id = 21, Title = "js-video(master)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video4 = new Video() { Id = 22, Title = "react-video(beginner)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video5 = new Video() { Id = 23, Title = "react-video(intermediate)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video6 = new Video() { Id = 24, Title = "react-video(master)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video7 = new Video() { Id = 25, Title = "c#-video(beginner)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video8 = new Video() { Id = 26, Title = "c#-video(intermediate)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video9 = new Video() { Id = 27, Title = "c#-video(master)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // Skills
        var skill1 = new Skill() { Id = 1, Name = "js-beginner", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill2 = new Skill() { Id = 2, Name = "js-intermediate", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill3 = new Skill() { Id = 3, Name = "js-master", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill4 = new Skill() { Id = 4, Name = "react-beginner", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill5 = new Skill() { Id = 5, Name = "react-intermediate", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill6 = new Skill() { Id = 6, Name = "react-master", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill7 = new Skill() { Id = 7, Name = "c#-beginner", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill8 = new Skill() { Id = 8, Name = "c#-intermediate", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill9 = new Skill() { Id = 9, Name = "c#-master", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // Courses
        var course1 = new Course() { Id = 1, Title = "js-course(beginner)", Description = "java script beginner course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course2 = new Course() { Id = 2, Title = "js-course(intermadiate)", Description = "java script intermadiate course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course3 = new Course() { Id = 3, Title = "js-course(master)", Description = "java script master course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course4 = new Course() { Id = 4, Title = "react-course(beginner)", Description = "react beginner course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course5 = new Course() { Id = 5, Title = "react-course(intermadiate)", Description = "react intermadiate course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course6 = new Course() { Id = 6, Title = "react-course(master)", Description = "react master course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course7 = new Course() { Id = 7, Title = "c#-course(beginner)", Description = "c# beginner course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course8 = new Course() { Id = 8, Title = "c#-course(intermadiate)", Description = "c# intermadiate course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course9 = new Course() { Id = 9, Title = "c#-course(naster)", Description = "c# master course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        modelBuilder.Entity<Format>().HasData(format1, format2, format3, format4, format5);
        modelBuilder.Entity<Quality>().HasData(quality1, quality2, quality3, quality4, quality5, quality6, quality7, quality8);
        modelBuilder.Entity<Article>().HasData(article1, article2, article3, article4, article5, article6, article7, article8, article9);
        modelBuilder.Entity<Ebook>().HasData(ebook1, ebook2, ebook3, ebook4, ebook5, ebook6, ebook7, ebook8, ebook9);
        modelBuilder.Entity<Video>().HasData(video1, video2, video3, video4, video5, video6, video7, video8, video9);
        modelBuilder.Entity<Role>().HasData(role1, role2, role3, role4);
        modelBuilder.Entity<Skill>().HasData(skill1, skill2, skill3, skill4, skill5, skill6, skill7, skill8, skill9);
        modelBuilder.Entity<Course>().HasData(course1, course2, course3, course4, course5, course6, course7, course8, course9);
        /* modelBuilder.Entity<User>().HasData(admin);
        modelBuilder.Entity<UserRole>().HasData(adminRole1, adminRole2, adminRole3, adminRole4); */
    }
}
