using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SummerWebinarApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedWeb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "WEBINARS",
                columns: new[] { "ID", "DESCRIPTION", "TEACHER_ID" },
                values: new object[] { 11, "Java", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WEBINARS",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.InsertData(
                table: "WEBINARS",
                columns: new[] { "ID", "DESCRIPTION", "TEACHER_ID" },
                values: new object[] { 12, "Java", 1 });
        }
    }
}
