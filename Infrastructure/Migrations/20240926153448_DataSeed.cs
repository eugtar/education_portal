using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Materials",
                columns: new[] { "Id", "Author", "FormatId", "PageAmount", "PublishedOn", "Title", "Type" },
                values: new object[,]
                {
                    { 10, "David Flanagan", 2, 1093, new DateTime(2024, 9, 26, 16, 34, 46, 166, DateTimeKind.Local).AddTicks(7698), "JS-EBook(Beginner)", "Ebook" },
                    { 11, "David Herman", 2, 228, new DateTime(2024, 9, 26, 16, 34, 46, 166, DateTimeKind.Local).AddTicks(7761), "JS-EBook(Intermediate)", "Ebook" },
                    { 12, "Nicholas C.Zakas", 3, 960, new DateTime(2024, 9, 26, 16, 34, 46, 166, DateTimeKind.Local).AddTicks(7765), "JS-EBook(Master)", "Ebook" },
                    { 13, "Robin Wieruch", 2, 286, new DateTime(2024, 9, 26, 16, 34, 46, 166, DateTimeKind.Local).AddTicks(7770), "React-EBook(Beginner)", "Ebook" },
                    { 14, "Adam Boduch", 3, 526, new DateTime(2024, 9, 26, 16, 34, 46, 166, DateTimeKind.Local).AddTicks(7774), "React-EBook(Intermediate)", "Ebook" },
                    { 15, "Carlos Santana Roldan", 3, 394, new DateTime(2024, 9, 26, 16, 34, 46, 166, DateTimeKind.Local).AddTicks(7778), "React-EBook(Master)", "Ebook" },
                    { 16, "RB Whitaker", 1, 406, new DateTime(2024, 9, 26, 16, 34, 46, 166, DateTimeKind.Local).AddTicks(7782), "C#-EBook(Beginner)", "Ebook" },
                    { 17, "Ian Griffiths", 2, 778, new DateTime(2024, 9, 26, 16, 34, 46, 166, DateTimeKind.Local).AddTicks(7786), "C#-EBook(Intermediate)", "Ebook" },
                    { 18, "Mark J.Price", 2, 826, new DateTime(2024, 9, 26, 16, 34, 46, 166, DateTimeKind.Local).AddTicks(7791), "C#-EBook(Master)", "Ebook" }
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
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashPassword", "LastName" },
                values: new object[,]
                {
                    { 1, "johndoe1@gmail.com", "John1", "1111", "Doe1" },
                    { 2, "johndoe2@gmail.com", "John2", "1111", "Doe2" },
                    { 3, "johndoe3@gmail.com", "John3", "1111", "Doe3" },
                    { 4, "johndoe4@gmail.com", "John4", "1111", "Doe4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
