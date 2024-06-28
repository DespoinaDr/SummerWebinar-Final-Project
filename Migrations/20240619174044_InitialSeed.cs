using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SummerWebinarApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TEACHERS_COURSES",
                table: "WEBINARS");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TEACHERS_WEBINARS",
                table: "WEBINARS",
                column: "TEACHER_ID",
                principalTable: "TEACHERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TEACHERS_WEBINARS",
                table: "WEBINARS");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TEACHERS_COURSES",
                table: "WEBINARS",
                column: "TEACHER_ID",
                principalTable: "TEACHERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
