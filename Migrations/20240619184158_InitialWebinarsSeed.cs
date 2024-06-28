using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SummerWebinarApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialWebinarsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "DESCRIPTION", "TEACHER_ID" },
                values: new object[] { "Python", 4 });

            migrationBuilder.UpdateData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "DESCRIPTION", "TEACHER_ID" },
                values: new object[] { "Android", 6 });

            migrationBuilder.InsertData(
                table: "WEBINARS",
                columns: new[] { "ID", "DESCRIPTION", "TEACHER_ID" },
                values: new object[,]
                {
                    { 8, "Java", 1 },
                    { 9, "JavaScript", 2 },
                    { 10, "MSSQL", 3 },
                    { 12, "Angular", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "DESCRIPTION", "TEACHER_ID" },
                values: new object[] { "Java", 1 });

            migrationBuilder.UpdateData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "DESCRIPTION", "TEACHER_ID" },
                values: new object[] { "JavaScript", 2 });

            migrationBuilder.InsertData(
                table: "WEBINARS",
                columns: new[] { "ID", "DESCRIPTION", "TEACHER_ID" },
                values: new object[,]
                {
                    { 14, "MSSQL", 3 },
                    { 15, "Python", 4 },
                    { 16, "Angular", 5 },
                    { 17, "Android", 6 }
                });
        }
    }
}
