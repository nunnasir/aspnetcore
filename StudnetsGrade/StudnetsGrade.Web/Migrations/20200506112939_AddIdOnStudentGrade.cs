using Microsoft.EntityFrameworkCore.Migrations;

namespace StudnetsGrade.Web.Migrations
{
    public partial class AddIdOnStudentGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentGrade",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentGrade");
        }
    }
}
