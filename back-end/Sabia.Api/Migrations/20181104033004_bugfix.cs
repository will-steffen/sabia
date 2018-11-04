using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabia.Api.Migrations
{
    public partial class bugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_User_CourseId",
                table: "UserCourses");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_User_UserId",
                table: "UserCourses",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_User_UserId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_User_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
