using Domain.Entities;
using Domain.Entities.RoleGroup;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // DateTime
        var dateTimeNow = DateTime.UtcNow;

        // Roles
        var role1 = new Role() { Id = 1, Name = "Administrator", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var role2 = new Role() { Id = 2, Name = "Theacher", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var role3 = new Role() { Id = 3, Name = "Student", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var role4 = new Role() { Id = 4, Name = "Guest", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

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

        // Articles
        var article1 = new Article() { Id = 1, Title = "JS-Article(Beginner) ", Link = "https://www.w3schools.com/js/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article2 = new Article() { Id = 2, Title = "JS-Article(Intermediate)", Link = "https://www.w3schools.com/js/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article3 = new Article() { Id = 3, Title = "JS-Article(Master)", Link = "https://www.w3schools.com/js/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article4 = new Article() { Id = 4, Title = "React-Article(Beginner)", Link = "https://www.w3schools.com/react/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article5 = new Article() { Id = 5, Title = "React-Article(Intermediate)", Link = "https://www.w3schools.com/react/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article6 = new Article() { Id = 6, Title = "React-Article(Master)", Link = "https://www.w3schools.com/react/default.asp", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article7 = new Article() { Id = 7, Title = "C#-Article(Beginner)", Link = "https://www.w3schools.com/cs/index.php", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article8 = new Article() { Id = 8, Title = "C#-Article(Intermediate)", Link = "https://www.w3schools.com/cs/index.php", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var article9 = new Article() { Id = 9, Title = "C#-Article(Master)", Link = "https://www.w3schools.com/cs/index.php", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // Ebooks
        var ebook1 = new Ebook() { Id = 10, Title = "JS-EBook(Beginner)", Author = "David Flanagan", PageAmount = 1093, PublishedOn = dateTimeNow, FormatId = 2, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook2 = new Ebook() { Id = 11, Title = "JS-EBook(Intermediate)", Author = "David Herman", PageAmount = 228, PublishedOn = dateTimeNow, FormatId = 2, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook3 = new Ebook() { Id = 12, Title = "JS-EBook(Master)", Author = "Nicholas C.Zakas", PageAmount = 960, PublishedOn = dateTimeNow, FormatId = 3, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook4 = new Ebook() { Id = 13, Title = "React-EBook(Beginner)", Author = "Robin Wieruch", PageAmount = 286, PublishedOn = dateTimeNow, FormatId = 2, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook5 = new Ebook() { Id = 14, Title = "React-EBook(Intermediate)", Author = "Adam Boduch", PageAmount = 526, PublishedOn = dateTimeNow, FormatId = 3, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook6 = new Ebook() { Id = 15, Title = "React-EBook(Master)", Author = "Carlos Santana Roldan", PageAmount = 394, PublishedOn = dateTimeNow, FormatId = 3, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook7 = new Ebook() { Id = 16, Title = "C#-EBook(Beginner)", Author = "RB Whitaker", PageAmount = 406, PublishedOn = dateTimeNow, FormatId = 1, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook8 = new Ebook() { Id = 17, Title = "C#-EBook(Intermediate)", Author = "Ian Griffiths", PageAmount = 778, PublishedOn = dateTimeNow, FormatId = 2, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var ebook9 = new Ebook() { Id = 18, Title = "C#-EBook(Master)", Author = "Mark J.Price", PageAmount = 826, PublishedOn = dateTimeNow, FormatId = 2, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // Videos
        var video1 = new Video() { Id = 19, Title = "JS-Video(Beginner)", Duration = new TimeOnly(1, 30, 25), QualityId = 5, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video2 = new Video() { Id = 20, Title = "JS-Video(Intermediate)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video3 = new Video() { Id = 21, Title = "JS-Video(Master)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video4 = new Video() { Id = 22, Title = "React-Video(Beginner)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video5 = new Video() { Id = 23, Title = "React-Video(Intermediate)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video6 = new Video() { Id = 24, Title = "React-Video(Master)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video7 = new Video() { Id = 25, Title = "C#-Video(Beginner)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video8 = new Video() { Id = 26, Title = "C#-Video(Intermediate)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var video9 = new Video() { Id = 27, Title = "C#-Video(Master)", Duration = new TimeOnly(1, 30, 25), QualityId = 6, CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // Skills
        var skill1 = new Skill() { Id = 1, Name = "JS-Beginner", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill2 = new Skill() { Id = 2, Name = "JS-Intermediate", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill3 = new Skill() { Id = 3, Name = "JS-Master", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill4 = new Skill() { Id = 4, Name = "React-Beginner", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill5 = new Skill() { Id = 5, Name = "React-Intermediate", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill6 = new Skill() { Id = 6, Name = "React-Master", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill7 = new Skill() { Id = 7, Name = "C#-Beginner", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill8 = new Skill() { Id = 8, Name = "C#-Intermediate", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var skill9 = new Skill() { Id = 9, Name = "C#-Master", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        // Courses
        var course1 = new Course() { Id = 1, Title = "JSCourse(Beginner)", Description = "JavaScript beginner course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course2 = new Course() { Id = 2, Title = "JSCourse(Intermadiate)", Description = "JavaScript intermadiate course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course3 = new Course() { Id = 3, Title = "JSCourse(Master)", Description = "JavaScript master course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course4 = new Course() { Id = 4, Title = "ReactJSCourse(Beginner)", Description = "React beginner course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course5 = new Course() { Id = 5, Title = "ReactJSCourse(Intermadiate)", Description = "React intermadiate course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course6 = new Course() { Id = 6, Title = "ReactJSCourse(Master)", Description = "React master course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course7 = new Course() { Id = 7, Title = "CSCourse(Beginner)", Description = "C# beginner course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course8 = new Course() { Id = 8, Title = "CSCourse(Intermadiate)", Description = "C# intermadiate course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };
        var course9 = new Course() { Id = 9, Title = "CSCourse(Master)", Description = "C# master course", CreatedAt = dateTimeNow, UpdatedAt = dateTimeNow };

        modelBuilder.Entity<Format>().HasData(format1, format2, format3, format4, format5);
        modelBuilder.Entity<Quality>().HasData(quality1, quality2, quality3, quality4, quality5, quality6, quality7, quality8);
        modelBuilder.Entity<Article>().HasData(article1, article2, article3, article4, article5, article6, article7, article8, article9);
        modelBuilder.Entity<Ebook>().HasData(ebook1, ebook2, ebook3, ebook4, ebook5, ebook6, ebook7, ebook8, ebook9);
        modelBuilder.Entity<Video>().HasData(video1, video2, video3, video4, video5, video6, video7, video8, video9);
        modelBuilder.Entity<Role>().HasData(role1, role2, role3, role4);
        modelBuilder.Entity<Skill>().HasData(skill1, skill2, skill3, skill4, skill5, skill6, skill7, skill8, skill9);
        modelBuilder.Entity<Course>().HasData(course1, course2, course3, course4, course5, course6, course7, course8, course9);
    }
}
