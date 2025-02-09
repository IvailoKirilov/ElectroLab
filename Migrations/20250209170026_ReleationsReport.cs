using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroLab.Migrations
{
    /// <inheritdoc />
    public partial class ReleationsReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Courses_CourseId",
                table: "Reports");

            migrationBuilder.AlterColumn<string>(
                name: "UserReportedId",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserReportedId",
                table: "Reports",
                column: "UserReportedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_UserReportedId",
                table: "Reports",
                column: "UserReportedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Courses_CourseId",
                table: "Reports",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_UserReportedId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Courses_CourseId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_UserReportedId",
                table: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "UserReportedId",
                table: "Reports",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Courses_CourseId",
                table: "Reports",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
