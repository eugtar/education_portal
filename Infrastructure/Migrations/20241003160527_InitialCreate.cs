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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                columns: new[] { "Id", "FormatType" },
                values: new object[,]
                {
                    { 1, "epub" },
                    { 2, "pdf" },
                    { 3, "docx" },
                    { 4, "azw" },
                    { 5, "txt" }
                });

            migrationBuilder.InsertData(
                table: "Qualities",
                columns: new[] { "Id", "QualityType" },
                values: new object[,]
                {
                    { 1, "144p" },
                    { 2, "240p" },
                    { 3, "360p" },
                    { 4, "480p" },
                    { 5, "720p" },
                    { 6, "1080p" },
                    { 7, "1440p" },
                    { 8, "2160p" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "JavaScript beginner course", "JSCourse(Beginner)" },
                    { 2, "JavaScript intermadiate course", "JSCourse(Intermadiate)" },
                    { 3, "JavaScript master course", "JSCourse(Master)" },
                    { 4, "React beginner course", "ReactJSCourse(Beginner)" },
                    { 5, "React intermadiate course", "ReactJSCourse(Intermadiate)" },
                    { 6, "React master course", "ReactJSCourse(Master)" },
                    { 7, "C# beginner course", "CSCourse(Beginner)" },
                    { 8, "C# intermadiate course", "CSCourse(Intermadiate)" },
                    { 9, "C# master course", "CSCourse(Master)" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Link", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "https://www.w3schools.com/js/default.asp", "JS-Article(Beginner) ", "Article" },
                    { 2, "https://www.w3schools.com/js/default.asp", "JS-Article(Intermediate)", "Article" },
                    { 3, "https://www.w3schools.com/js/default.asp", "JS-Article(Master)", "Article" },
                    { 4, "https://www.w3schools.com/react/default.asp", "React-Article(Beginner)", "Article" },
                    { 5, "https://www.w3schools.com/react/default.asp", "React-Article(Intermediate)", "Article" },
                    { 6, "https://www.w3schools.com/react/default.asp", "React-Article(Master)", "Article" },
                    { 7, "https://www.w3schools.com/cs/index.php", "C#-Article(Beginner)", "Article" },
                    { 8, "https://www.w3schools.com/cs/index.php", "C#-Article(Intermediate)", "Article" },
                    { 9, "https://www.w3schools.com/cs/index.php", "C#-Article(Master)", "Article" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "JS-Beginner" },
                    { 2, "JS-Intermediate" },
                    { 3, "JS-Master" },
                    { 4, "React-Beginner" },
                    { 5, "React-Intermediate" },
                    { 6, "React-Master" },
                    { 7, "C#-Beginner" },
                    { 8, "C#-Intermediate" },
                    { 9, "C#-Master" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashPassword", "LastName" },
                values: new object[,]
                {
                    { 1, "johndoe1@gmail.com", "John1", "1111", "Doe1" },
                    { 2, "johndoe2@gmail.com", "John2", "1111", "Doe2" },
                    { 3, "johndoe3@gmail.com", "John3", "1111", "Doe3" },
                    { 4, "johndoe4@gmail.com", "John4", "1111", "Doe4" }
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
                columns: new[] { "Id", "Author", "FormatId", "PageAmount", "PublishedOn", "Title", "Type" },
                values: new object[,]
                {
                    { 10, "David Flanagan", 2, 1093, new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4449), "JS-EBook(Beginner)", "Ebook" },
                    { 11, "David Herman", 2, 228, new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4536), "JS-EBook(Intermediate)", "Ebook" },
                    { 12, "Nicholas C.Zakas", 3, 960, new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4567), "JS-EBook(Master)", "Ebook" },
                    { 13, "Robin Wieruch", 2, 286, new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4575), "React-EBook(Beginner)", "Ebook" },
                    { 14, "Adam Boduch", 3, 526, new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4580), "React-EBook(Intermediate)", "Ebook" },
                    { 15, "Carlos Santana Roldan", 3, 394, new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4585), "React-EBook(Master)", "Ebook" },
                    { 16, "RB Whitaker", 1, 406, new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4590), "C#-EBook(Beginner)", "Ebook" },
                    { 17, "Ian Griffiths", 2, 778, new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4595), "C#-EBook(Intermediate)", "Ebook" },
                    { 18, "Mark J.Price", 2, 826, new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4600), "C#-EBook(Master)", "Ebook" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Duration", "QualityId", "Title", "Type" },
                values: new object[,]
                {
                    { 19, new TimeOnly(1, 30, 25), 5, "JS-Video(Beginner)", "Video" },
                    { 20, new TimeOnly(1, 30, 25), 6, "JS-Video(Intermediate)", "Video" },
                    { 21, new TimeOnly(1, 30, 25), 6, "JS-Video(Master)", "Video" },
                    { 22, new TimeOnly(1, 30, 25), 6, "React-Video(Beginner)", "Video" },
                    { 23, new TimeOnly(1, 30, 25), 6, "React-Video(Intermediate)", "Video" },
                    { 24, new TimeOnly(1, 30, 25), 6, "React-Video(Master)", "Video" },
                    { 25, new TimeOnly(1, 30, 25), 6, "C#-Video(Beginner)", "Video" },
                    { 26, new TimeOnly(1, 30, 25), 6, "C#-Video(Intermediate)", "Video" },
                    { 27, new TimeOnly(1, 30, 25), 6, "C#-Video(Master)", "Video" }
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
