using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SummerWebinarApp.Migrations
{
    /// <inheritdoc />
    public partial class AddLastnameToTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "TEACHERS",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "TEACHERS");
        }
    }
}
