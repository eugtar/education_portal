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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
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
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "epub", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 2, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "pdf", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 3, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "docx", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 4, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "azw", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 5, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "txt", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) }
                });

            migrationBuilder.InsertData(
                table: "Qualities",
                columns: new[] { "Id", "CreatedAt", "QualityType", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "144p", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 2, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "240p", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 3, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "360p", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 4, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "480p", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 5, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "720p", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 6, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "1080p", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 7, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "1440p", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 8, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "2160p", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "administrator", "ADMINISTRATOR", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 2, null, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "teacher", "TEACHER", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 3, null, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "student", "STUDENT", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 4, null, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "guest", "GUEST", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Description", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "java script beginner course", "js-course(beginner)", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 2, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "java script intermadiate course", "js-course(intermadiate)", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 3, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "java script master course", "js-course(master)", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 4, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "react beginner course", "react-course(beginner)", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 5, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "react intermadiate course", "react-course(intermadiate)", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 6, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "react master course", "react-course(master)", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 7, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "c# beginner course", "c#-course(beginner)", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 8, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "c# intermadiate course", "c#-course(intermadiate)", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 9, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "c# master course", "c#-course(naster)", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "CreatedAt", "Link", "Title", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "https://www.w3schools.com/js/default.asp", "js-article(beginner) ", "Article", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 2, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "https://www.w3schools.com/js/default.asp", "js-article(intermediate)", "Article", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 3, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "https://www.w3schools.com/js/default.asp", "js-article(master)", "Article", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 4, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "https://www.w3schools.com/react/default.asp", "react-article(beginner)", "Article", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 5, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "https://www.w3schools.com/react/default.asp", "react-article(intermediate)", "Article", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 6, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "https://www.w3schools.com/react/default.asp", "react-article(master)", "Article", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 7, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "https://www.w3schools.com/cs/index.php", "c#-article(beginner)", "Article", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 8, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "https://www.w3schools.com/cs/index.php", "c#-article(intermediate)", "Article", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 9, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "https://www.w3schools.com/cs/index.php", "c#-article(master)", "Article", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "js-beginner", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 2, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "js-intermediate", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 3, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "js-master", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 4, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "react-beginner", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 5, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "react-intermediate", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 6, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "react-master", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 7, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "c#-beginner", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 8, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "c#-intermediate", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 9, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "c#-master", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) }
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
                    { 10, "david flanagan", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), 2, 1093, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "js-ebook(beginner)", "Ebook", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 11, "david herman", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), 2, 228, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "js-ebook(intermediate)", "Ebook", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 12, "nicholas c.zakas", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), 3, 960, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "js-ebook(master)", "Ebook", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 13, "robin wieruch", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), 2, 286, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "react-ebook(beginner)", "Ebook", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 14, "adam boduch", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), 3, 526, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "react-ebook(intermediate)", "Ebook", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 15, "carlos santana roldan", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), 3, 394, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "react-ebook(master)", "Ebook", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 16, "r.b. whitaker", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), 1, 406, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "c#-ebook(beginner)", "Ebook", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 17, "ian griffiths", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), 2, 778, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "c#-ebook(intermediate)", "Ebook", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 18, "mark j.price", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), 2, 826, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), "c#-ebook(master)", "Ebook", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "CreatedAt", "Duration", "QualityId", "Title", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 19, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), new TimeOnly(1, 30, 25), 5, "js-video(beginner)", "Video", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 20, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), new TimeOnly(1, 30, 25), 6, "js-video(intermediate)", "Video", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 21, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), new TimeOnly(1, 30, 25), 6, "js-video(master)", "Video", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 22, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), new TimeOnly(1, 30, 25), 6, "react-video(beginner)", "Video", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 23, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), new TimeOnly(1, 30, 25), 6, "react-video(intermediate)", "Video", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 24, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), new TimeOnly(1, 30, 25), 6, "react-video(master)", "Video", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 25, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), new TimeOnly(1, 30, 25), 6, "c#-video(beginner)", "Video", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 26, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), new TimeOnly(1, 30, 25), 6, "c#-video(intermediate)", "Video", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) },
                    { 27, new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986), new TimeOnly(1, 30, 25), 6, "c#-video(master)", "Video", new DateTime(2024, 12, 20, 12, 18, 45, 149, DateTimeKind.Utc).AddTicks(1986) }
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
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Skills",
                table: "Skills",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UQ__Users",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Roles");

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
