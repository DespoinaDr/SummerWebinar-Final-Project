using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SummerWebinarApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "WEBINARS",
                columns: new[] { "ID", "DESCRIPTION", "TEACHER_ID" },
                values: new object[,]
                {
                    { 12, "Java", 1 },
                    { 13, "JavaScript", 2 },
                    { 14, "MSSQL", 3 },
                    { 15, "Python", 4 },
                    { 16, "Angular", 5 },
                    { 17, "Android", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.InsertData(
                table: "WEBINARS",
                columns: new[] { "ID", "DESCRIPTION", "TEACHER_ID" },
                values: new object[,]
                {
                    { 1, "Java", 1 },
                    { 2, "JavaScript", 2 },
                    { 3, "MSSQL", 3 },
                    { 4, "Python", 4 },
                    { 5, "Angular", 5 },
                    { 6, "Android", 6 }
                });
        }
    }
}
