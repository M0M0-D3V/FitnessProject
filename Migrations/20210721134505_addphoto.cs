using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessProject.Migrations
{
    public partial class addphoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructorPhoto",
                table: "Instructors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorPhoto",
                table: "Instructors");
        }
    }
}
