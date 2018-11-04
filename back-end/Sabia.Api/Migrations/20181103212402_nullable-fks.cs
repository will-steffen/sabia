using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabia.Api.Migrations
{
    public partial class nullablefks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_RequirementCourseId",
                table: "Courses");

            migrationBuilder.AlterColumn<long>(
                name: "RequirementCourseId",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_RequirementCourseId",
                table: "Courses",
                column: "RequirementCourseId",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_RequirementCourseId",
                table: "Courses");

            migrationBuilder.AlterColumn<long>(
                name: "RequirementCourseId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_RequirementCourseId",
                table: "Courses",
                column: "RequirementCourseId",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
