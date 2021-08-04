using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessProject.Migrations
{
    public partial class Messages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_MyMessageId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_MyMessageId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "MyMessageId",
                table: "Message");

            migrationBuilder.AddColumn<string>(
                name: "MessageFromId",
                table: "Message",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_MessageFromId",
                table: "Message",
                column: "MessageFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_MessageFromId",
                table: "Message",
                column: "MessageFromId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_MessageFromId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_MessageFromId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "MessageFromId",
                table: "Message");

            migrationBuilder.AddColumn<string>(
                name: "MyMessageId",
                table: "Message",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_MyMessageId",
                table: "Message",
                column: "MyMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_MyMessageId",
                table: "Message",
                column: "MyMessageId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
