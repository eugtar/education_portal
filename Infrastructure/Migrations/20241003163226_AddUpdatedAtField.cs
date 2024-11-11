using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedAtField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(sysdatetime())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Skills",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(sysdatetime())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Qualities",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(sysdatetime())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(sysdatetime())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Formats",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(sysdatetime())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(sysdatetime())");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 32, 18, 229, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 32, 18, 229, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 32, 18, 229, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 13,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 32, 18, 229, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 14,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 32, 18, 229, DateTimeKind.Local).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 15,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 32, 18, 229, DateTimeKind.Local).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 16,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 32, 18, 229, DateTimeKind.Local).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 17,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 32, 18, 229, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 18,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 32, 18, 229, DateTimeKind.Local).AddTicks(5000));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Skills",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Qualities",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Formats",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 13,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 14,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 15,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 16,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 17,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 18,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 3, 17, 5, 25, 608, DateTimeKind.Local).AddTicks(4600));
        }
    }
}
