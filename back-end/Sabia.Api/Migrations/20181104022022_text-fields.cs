using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabia.Api.Migrations
{
    public partial class textfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BaseCode",
                table: "Jobs",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Jobs",
                type: "LONGTEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseCode",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Jobs");
        }
    }
}
