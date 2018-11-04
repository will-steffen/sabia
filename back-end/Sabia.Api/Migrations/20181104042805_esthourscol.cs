using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabia.Api.Migrations
{
    public partial class esthourscol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "UsedHours",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<float>(
                name: "EstimatedHours",
                table: "Jobs",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedHours",
                table: "Jobs");

            migrationBuilder.AlterColumn<long>(
                name: "UsedHours",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
