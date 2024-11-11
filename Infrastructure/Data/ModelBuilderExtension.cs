using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Qualities
        var quality1 = new Quality() { Id = 1, QualityType = "144p" };
        var quality2 = new Quality() { Id = 2, QualityType = "240p" };
        var quality3 = new Quality() { Id = 3, QualityType = "360p" };
        var quality4 = new Quality() { Id = 4, QualityType = "480p" };
        var quality5 = new Quality() { Id = 5, QualityType = "720p" };
        var quality6 = new Quality() { Id = 6, QualityType = "1080p" };
        var quality7 = new Quality() { Id = 7, QualityType = "1440p" };
        var quality8 = new Quality() { Id = 8, QualityType = "2160p" };

        // Formats
        var format1 = new Format() { Id = 1, FormatType = "epub" };
        var format2 = new Format() { Id = 2, FormatType = "pdf" };
        var format3 = new Format() { Id = 3, FormatType = "docx" };
        var format4 = new Format() { Id = 4, FormatType = "azw" };
        var format5 = new Format() { Id = 5, FormatType = "txt" };

        // Articles
        var article1 = new Article() { Id = 1, Title = "JS-Article(Beginner) ", Link = "https://www.w3schools.com/js/default.asp" };
        var article2 = new Article() { Id = 2, Title = "JS-Article(Intermediate)", Link = "https://www.w3schools.com/js/default.asp" };
        var article3 = new Article() { Id = 3, Title = "JS-Article(Master)", Link = "https://www.w3schools.com/js/default.asp" };
        var article4 = new Article() { Id = 4, Title = "React-Article(Beginner)", Link = "https://www.w3schools.com/react/default.asp" };
        var article5 = new Article() { Id = 5, Title = "React-Article(Intermediate)", Link = "https://www.w3schools.com/react/default.asp" };
        var article6 = new Article() { Id = 6, Title = "React-Article(Master)", Link = "https://www.w3schools.com/react/default.asp" };
        var article7 = new Article() { Id = 7, Title = "C#-Article(Beginner)", Link = "https://www.w3schools.com/cs/index.php" };
        var article8 = new Article() { Id = 8, Title = "C#-Article(Intermediate)", Link = "https://www.w3schools.com/cs/index.php" };
        var article9 = new Article() { Id = 9, Title = "C#-Article(Master)", Link = "https://www.w3schools.com/cs/index.php" };

        // Ebooks
        var ebook1 = new Ebook() { Id = 10, Title = "JS-EBook(Beginner)", Author = "David Flanagan", PageAmount = 1093, PublishedOn = DateTime.Now, FormatId = 2 };
        var ebook2 = new Ebook() { Id = 11, Title = "JS-EBook(Intermediate)", Author = "David Herman", PageAmount = 228, PublishedOn = DateTime.Now, FormatId = 2 };
        var ebook3 = new Ebook() { Id = 12, Title = "JS-EBook(Master)", Author = "Nicholas C.Zakas", PageAmount = 960, PublishedOn = DateTime.Now, FormatId = 3 };
        var ebook4 = new Ebook() { Id = 13, Title = "React-EBook(Beginner)", Author = "Robin Wieruch", PageAmount = 286, PublishedOn = DateTime.Now, FormatId = 2 };
        var ebook5 = new Ebook() { Id = 14, Title = "React-EBook(Intermediate)", Author = "Adam Boduch", PageAmount = 526, PublishedOn = DateTime.Now, FormatId = 3 };
        var ebook6 = new Ebook() { Id = 15, Title = "React-EBook(Master)", Author = "Carlos Santana Roldan", PageAmount = 394, PublishedOn = DateTime.Now, FormatId = 3 };
        var ebook7 = new Ebook() { Id = 16, Title = "C#-EBook(Beginner)", Author = "RB Whitaker", PageAmount = 406, PublishedOn = DateTime.Now, FormatId = 1 };
        var ebook8 = new Ebook() { Id = 17, Title = "C#-EBook(Intermediate)", Author = "Ian Griffiths", PageAmount = 778, PublishedOn = DateTime.Now, FormatId = 2 };
        var ebook9 = new Ebook() { Id = 18, Title = "C#-EBook(Master)", Author = "Mark J.Price", PageAmount = 826, PublishedOn = DateTime.Now, FormatId = 2 };

        // Videos
        var video1 = new Video() { Id = 19, Title = "JS-Video(Beginner)", Duration = new TimeOnly(1, 30, 25), QualityId = 5 };
        var video2 = new Video() { Id = 20, Title = "JS-Video(Intermediate)", Duration = new TimeOnly(1, 30, 25), QualityId = 6 };
        var video3 = new Video() { Id = 21, Title = "JS-Video(Master)", Duration = new TimeOnly(1, 30, 25), QualityId = 6 };
        var video4 = new Video() { Id = 22, Title = "React-Video(Beginner)", Duration = new TimeOnly(1, 30, 25), QualityId = 6 };
        var video5 = new Video() { Id = 23, Title = "React-Video(Intermediate)", Duration = new TimeOnly(1, 30, 25), QualityId = 6 };
        var video6 = new Video() { Id = 24, Title = "React-Video(Master)", Duration = new TimeOnly(1, 30, 25), QualityId = 6 };
        var video7 = new Video() { Id = 25, Title = "C#-Video(Beginner)", Duration = new TimeOnly(1, 30, 25), QualityId = 6 };
        var video8 = new Video() { Id = 26, Title = "C#-Video(Intermediate)", Duration = new TimeOnly(1, 30, 25), QualityId = 6 };
        var video9 = new Video() { Id = 27, Title = "C#-Video(Master)", Duration = new TimeOnly(1, 30, 25), QualityId = 6 };

        // Skills
        var skill1 = new Skill() { Id = 1, Name = "JS-Beginner" };
        var skill2 = new Skill() { Id = 2, Name = "JS-Intermediate" };
        var skill3 = new Skill() { Id = 3, Name = "JS-Master" };
        var skill4 = new Skill() { Id = 4, Name = "React-Beginner" };
        var skill5 = new Skill() { Id = 5, Name = "React-Intermediate" };
        var skill6 = new Skill() { Id = 6, Name = "React-Master" };
        var skill7 = new Skill() { Id = 7, Name = "C#-Beginner" };
        var skill8 = new Skill() { Id = 8, Name = "C#-Intermediate" };
        var skill9 = new Skill() { Id = 9, Name = "C#-Master" };

        // Users
        var user1 = new User() { Id = 1, FirstName = "John1", LastName = "Doe1", Email = "johndoe1@gmail.com", HashPassword = "1111" };
        var user2 = new User() { Id = 2, FirstName = "John2", LastName = "Doe2", Email = "johndoe2@gmail.com", HashPassword = "1111" };
        var user3 = new User() { Id = 3, FirstName = "John3", LastName = "Doe3", Email = "johndoe3@gmail.com", HashPassword = "1111" };
        var user4 = new User() { Id = 4, FirstName = "John4", LastName = "Doe4", Email = "johndoe4@gmail.com", HashPassword = "1111" };

        // Courses
        var course1 = new Course() { Id = 1, Title = "JSCourse(Beginner)", Description = "JavaScript beginner course" };
        var course2 = new Course() { Id = 2, Title = "JSCourse(Intermadiate)", Description = "JavaScript intermadiate course" };
        var course3 = new Course() { Id = 3, Title = "JSCourse(Master)", Description = "JavaScript master course" };
        var course4 = new Course() { Id = 4, Title = "ReactJSCourse(Beginner)", Description = "React beginner course" };
        var course5 = new Course() { Id = 5, Title = "ReactJSCourse(Intermadiate)", Description = "React intermadiate course" };
        var course6 = new Course() { Id = 6, Title = "ReactJSCourse(Master)", Description = "React master course" };
        var course7 = new Course() { Id = 7, Title = "CSCourse(Beginner)", Description = "C# beginner course" };
        var course8 = new Course() { Id = 8, Title = "CSCourse(Intermadiate)", Description = "C# intermadiate course" };
        var course9 = new Course() { Id = 9, Title = "CSCourse(Master)", Description = "C# master course" };

        modelBuilder.Entity<Format>().HasData(format1, format2, format3, format4, format5);
        modelBuilder.Entity<Quality>().HasData(quality1, quality2, quality3, quality4, quality5, quality6, quality7, quality8);
        modelBuilder.Entity<Article>().HasData(article1, article2, article3, article4, article5, article6, article7, article8, article9);
        modelBuilder.Entity<Ebook>().HasData(ebook1, ebook2, ebook3, ebook4, ebook5, ebook6, ebook7, ebook8, ebook9);
        modelBuilder.Entity<Video>().HasData(video1, video2, video3, video4, video5, video6, video7, video8, video9);
        modelBuilder.Entity<User>().HasData(user1, user2, user3, user4);
        modelBuilder.Entity<Skill>().HasData(skill1, skill2, skill3, skill4, skill5, skill6, skill7, skill8, skill9);
        modelBuilder.Entity<Course>().HasData(course1, course2, course3, course4, course5, course6, course7, course8, course9);
    }
}
