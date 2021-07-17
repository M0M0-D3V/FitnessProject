using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessProject.Migrations
{
    public partial class RSVPs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVP_classes_ClassId",
                table: "RSVP");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVP_AspNetUsers_UserId",
                table: "RSVP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RSVP",
                table: "RSVP");

            migrationBuilder.RenameTable(
                name: "RSVP",
                newName: "RSVPs");

            migrationBuilder.RenameIndex(
                name: "IX_RSVP_UserId",
                table: "RSVPs",
                newName: "IX_RSVPs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVP_ClassId",
                table: "RSVPs",
                newName: "IX_RSVPs_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RSVPs",
                table: "RSVPs",
                column: "RSVPId");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_classes_ClassId",
                table: "RSVPs",
                column: "ClassId",
                principalTable: "classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_AspNetUsers_UserId",
                table: "RSVPs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_classes_ClassId",
                table: "RSVPs");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_AspNetUsers_UserId",
                table: "RSVPs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RSVPs",
                table: "RSVPs");

            migrationBuilder.RenameTable(
                name: "RSVPs",
                newName: "RSVP");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPs_UserId",
                table: "RSVP",
                newName: "IX_RSVP_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPs_ClassId",
                table: "RSVP",
                newName: "IX_RSVP_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RSVP",
                table: "RSVP",
                column: "RSVPId");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVP_classes_ClassId",
                table: "RSVP",
                column: "ClassId",
                principalTable: "classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVP_AspNetUsers_UserId",
                table: "RSVP",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
