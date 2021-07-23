using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessProject.Migrations
{
    public partial class ClassVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassVideo",
                table: "Classes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassVideo",
                table: "Classes");
        }
    }
}
