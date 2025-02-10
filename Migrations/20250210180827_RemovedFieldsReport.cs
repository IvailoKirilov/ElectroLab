using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroLab.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFieldsReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_UserReportedId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_UserReportedId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "UserReportedId",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ApplicationUserId",
                table: "Reports",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_ApplicationUserId",
                table: "Reports",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_ApplicationUserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ApplicationUserId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "UserReportedId",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
