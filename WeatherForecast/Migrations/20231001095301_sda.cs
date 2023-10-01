using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherForecast.Migrations
{
    /// <inheritdoc />
    public partial class sda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Test",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId1",
                table: "Test",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "Student",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Grade",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId1",
                table: "Grade",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Test_StudentId1",
                table: "Test",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Test_SubjectId1",
                table: "Test",
                column: "SubjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupId1",
                table: "Student",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentId1",
                table: "Grade",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SubjectId1",
                table: "Grade",
                column: "SubjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Student_StudentId1",
                table: "Grade",
                column: "StudentId1",
                principalTable: "Student",
                principalColumn: "student_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Subjects_SubjectId1",
                table: "Grade",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "subject_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Groups_GroupId1",
                table: "Student",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Student_StudentId1",
                table: "Test",
                column: "StudentId1",
                principalTable: "Student",
                principalColumn: "student_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Subjects_SubjectId1",
                table: "Test",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "subject_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Student_StudentId1",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Subjects_SubjectId1",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Groups_GroupId1",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Student_StudentId1",
                table: "Test");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Subjects_SubjectId1",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_StudentId1",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_SubjectId1",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Student_GroupId1",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Grade_StudentId1",
                table: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Grade_SubjectId1",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "SubjectId1",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "SubjectId1",
                table: "Grade");
        }
    }
}
