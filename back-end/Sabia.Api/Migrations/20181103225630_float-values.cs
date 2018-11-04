using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabia.Api.Migrations
{
    public partial class floatvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.AlterColumn<float>(
                name: "UsedHours",
                table: "UserCourses",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<float>(
                name: "Progression",
                table: "UserCourses",
                nullable: false,
                oldClrType: typeof(long));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<long>(
                name: "UsedHours",
                table: "UserCourses",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<long>(
                name: "Progression",
                table: "UserCourses",
                nullable: false,
                oldClrType: typeof(float));

        }
    }
}
