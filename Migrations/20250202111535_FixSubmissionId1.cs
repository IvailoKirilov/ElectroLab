using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroLab.Migrations
{
    /// <inheritdoc />
    public partial class FixSubmissionId1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubmissionId1",
                table: "SubmissionAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionAnswers_SubmissionId1",
                table: "SubmissionAnswers",
                column: "SubmissionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmissionAnswers_Submissions_SubmissionId1",
                table: "SubmissionAnswers",
                column: "SubmissionId1",
                principalTable: "Submissions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmissionAnswers_Submissions_SubmissionId1",
                table: "SubmissionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SubmissionAnswers_SubmissionId1",
                table: "SubmissionAnswers");

            migrationBuilder.DropColumn(
                name: "SubmissionId1",
                table: "SubmissionAnswers");
        }
    }
}
