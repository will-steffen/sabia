using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabia.Api.Migrations
{
    public partial class hourstouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "MoneyEarned",
                table: "User",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "StudyHours",
                table: "User",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalHour",
                table: "User",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "WorkedHours",
                table: "User",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyEarned",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StudyHours",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TotalHour",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WorkedHours",
                table: "User");
        }
    }
}
