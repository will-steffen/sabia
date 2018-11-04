using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabia.Api.Migrations
{
    public partial class extdesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtendedDescription",
                table: "Jobs",
                maxLength: 800,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Objective",
                table: "Jobs",
                maxLength: 800,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtendedDescription",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Objective",
                table: "Jobs");
        }
    }
}
