using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FormatType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Formats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    QualityType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Qualities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PageAmount = table.Column<int>(type: "int", nullable: true),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    FormatId = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    Duration = table.Column<TimeOnly>(type: "time", nullable: true),
                    QualityId = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK__EBooks__FormatId",
                        column: x => x.FormatId,
                        principalTable: "Formats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Videos__QualityId",
                        column: x => x.QualityId,
                        principalTable: "Qualities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseSkill",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseSkill", x => new { x.CourseId, x.SkillId });
                    table.ForeignKey(
                        name: "FK__CourseSkill__Course",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__CourseSkill__Skill",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    Progress = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UserCourses__CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__UserCourses__UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UserSkills__SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__UserSkills__UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseMaterial",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseMaterial", x => new { x.CourseId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK__CourseMaterial__Course",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__CourseMaterial__Material",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Formats",
                columns: new[] { "Id", "CreatedAt", "FormatType", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "epub", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 2, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "pdf", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 3, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "docx", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 4, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "azw", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 5, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "txt", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) }
                });

            migrationBuilder.InsertData(
                table: "Qualities",
                columns: new[] { "Id", "CreatedAt", "QualityType", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "144p", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 2, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "240p", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 3, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "360p", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 4, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "480p", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 5, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "720p", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 6, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "1080p", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 7, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "1440p", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 8, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "2160p", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Description", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "JavaScript beginner course", "JSCourse(Beginner)", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 2, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "JavaScript intermadiate course", "JSCourse(Intermadiate)", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 3, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "JavaScript master course", "JSCourse(Master)", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 4, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "React beginner course", "ReactJSCourse(Beginner)", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 5, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "React intermadiate course", "ReactJSCourse(Intermadiate)", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 6, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "React master course", "ReactJSCourse(Master)", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 7, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "C# beginner course", "CSCourse(Beginner)", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 8, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "C# intermadiate course", "CSCourse(Intermadiate)", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 9, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "C# master course", "CSCourse(Master)", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "CreatedAt", "Link", "Title", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "https://www.w3schools.com/js/default.asp", "JS-Article(Beginner) ", "Article", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 2, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "https://www.w3schools.com/js/default.asp", "JS-Article(Intermediate)", "Article", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 3, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "https://www.w3schools.com/js/default.asp", "JS-Article(Master)", "Article", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 4, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "https://www.w3schools.com/react/default.asp", "React-Article(Beginner)", "Article", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 5, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "https://www.w3schools.com/react/default.asp", "React-Article(Intermediate)", "Article", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 6, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "https://www.w3schools.com/react/default.asp", "React-Article(Master)", "Article", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 7, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "https://www.w3schools.com/cs/index.php", "C#-Article(Beginner)", "Article", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 8, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "https://www.w3schools.com/cs/index.php", "C#-Article(Intermediate)", "Article", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 9, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "https://www.w3schools.com/cs/index.php", "C#-Article(Master)", "Article", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "JS-Beginner", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 2, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "JS-Intermediate", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 3, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "JS-Master", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 4, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "React-Beginner", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 5, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "React-Intermediate", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 6, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "React-Master", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 7, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "C#-Beginner", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 8, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "C#-Intermediate", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 9, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "C#-Master", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "HashPassword", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "johndoe1@gmail.com", "John1", "1111", "Doe1", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 2, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "johndoe2@gmail.com", "John2", "1111", "Doe2", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 3, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "johndoe3@gmail.com", "John3", "1111", "Doe3", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 4, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), "johndoe4@gmail.com", "John4", "1111", "Doe4", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) }
                });

            migrationBuilder.InsertData(
                table: "CourseMaterial",
                columns: new[] { "CourseId", "MaterialId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 }
                });

            migrationBuilder.InsertData(
                table: "CourseSkill",
                columns: new[] { "CourseId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 4 },
                    { 5, 5 },
                    { 6, 4 },
                    { 6, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 7 },
                    { 8, 8 },
                    { 9, 7 },
                    { 9, 8 },
                    { 9, 9 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Author", "CreatedAt", "FormatId", "PageAmount", "PublishedOn", "Title", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 10, "David Flanagan", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), 2, 1093, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Local).AddTicks(2178), "JS-EBook(Beginner)", "Ebook", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 11, "David Herman", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), 2, 228, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Local).AddTicks(2242), "JS-EBook(Intermediate)", "Ebook", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 12, "Nicholas C.Zakas", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), 3, 960, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Local).AddTicks(2248), "JS-EBook(Master)", "Ebook", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 13, "Robin Wieruch", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), 2, 286, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Local).AddTicks(2254), "React-EBook(Beginner)", "Ebook", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 14, "Adam Boduch", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), 3, 526, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Local).AddTicks(2259), "React-EBook(Intermediate)", "Ebook", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 15, "Carlos Santana Roldan", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), 3, 394, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Local).AddTicks(2265), "React-EBook(Master)", "Ebook", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 16, "RB Whitaker", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), 1, 406, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Local).AddTicks(2270), "C#-EBook(Beginner)", "Ebook", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 17, "Ian Griffiths", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), 2, 778, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Local).AddTicks(2275), "C#-EBook(Intermediate)", "Ebook", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 18, "Mark J.Price", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), 2, 826, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Local).AddTicks(2281), "C#-EBook(Master)", "Ebook", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "CreatedAt", "Duration", "QualityId", "Title", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 19, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), new TimeOnly(1, 30, 25), 5, "JS-Video(Beginner)", "Video", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 20, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), new TimeOnly(1, 30, 25), 6, "JS-Video(Intermediate)", "Video", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 21, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), new TimeOnly(1, 30, 25), 6, "JS-Video(Master)", "Video", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 22, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), new TimeOnly(1, 30, 25), 6, "React-Video(Beginner)", "Video", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 23, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), new TimeOnly(1, 30, 25), 6, "React-Video(Intermediate)", "Video", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 24, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), new TimeOnly(1, 30, 25), 6, "React-Video(Master)", "Video", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 25, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), new TimeOnly(1, 30, 25), 6, "C#-Video(Beginner)", "Video", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 26, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), new TimeOnly(1, 30, 25), 6, "C#-Video(Intermediate)", "Video", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) },
                    { 27, new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126), new TimeOnly(1, 30, 25), 6, "C#-Video(Master)", "Video", new DateTime(2024, 11, 8, 2, 44, 5, 288, DateTimeKind.Utc).AddTicks(2126) }
                });

            migrationBuilder.InsertData(
                table: "CourseMaterial",
                columns: new[] { "CourseId", "MaterialId" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 1, 19 },
                    { 2, 11 },
                    { 2, 20 },
                    { 3, 12 },
                    { 3, 21 },
                    { 4, 13 },
                    { 4, 22 },
                    { 5, 14 },
                    { 5, 23 },
                    { 6, 15 },
                    { 6, 24 },
                    { 7, 16 },
                    { 7, 25 },
                    { 8, 17 },
                    { 8, 26 },
                    { 9, 18 },
                    { 9, 27 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterial_MaterialId",
                table: "CourseMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSkill_SkillId",
                table: "CourseSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_FormatId",
                table: "Materials",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_QualityId",
                table: "Materials",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "UQ__Skills",
                table: "Skills",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ__Users",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_UserId",
                table: "UserSkills",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMaterial");

            migrationBuilder.DropTable(
                name: "CourseSkill");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "Qualities");
        }
    }
}
