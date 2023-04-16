using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class teaching3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherRequests_Teachers_TeacherId",
                table: "TeacherRequests");

            migrationBuilder.AddColumn<int>(
                name: "Reputation",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "TeacherRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "NameEn", "NameFa" },
                values: new object[] { "IELTS", "IELTS", "IELTS" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Reputation",
                value: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherRequests_Teachers_TeacherId",
                table: "TeacherRequests",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherRequests_Teachers_TeacherId",
                table: "TeacherRequests");

            migrationBuilder.DropColumn(
                name: "Reputation",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TeacherRequests");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "NameEn", "NameFa" },
                values: new object[] { "IELTS Speaking", "IELTS Speaking", "IELTS Speaking" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherRequests_Teachers_TeacherId",
                table: "TeacherRequests",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
