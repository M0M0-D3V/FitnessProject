using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessProject.Migrations
{
    public partial class Community2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeReviews_ReviewClasses_LikedClassReviewReviewClassId",
                table: "LikeReviews");

            migrationBuilder.DropIndex(
                name: "IX_LikeReviews_LikedClassReviewReviewClassId",
                table: "LikeReviews");

            migrationBuilder.DropColumn(
                name: "LikedClassReviewReviewClassId",
                table: "LikeReviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "LikeReviews");

            migrationBuilder.AddColumn<int>(
                name: "ReviewClassId",
                table: "LikeReviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LikeReviews_ReviewClassId",
                table: "LikeReviews",
                column: "ReviewClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeReviews_ReviewClasses_ReviewClassId",
                table: "LikeReviews",
                column: "ReviewClassId",
                principalTable: "ReviewClasses",
                principalColumn: "ReviewClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeReviews_ReviewClasses_ReviewClassId",
                table: "LikeReviews");

            migrationBuilder.DropIndex(
                name: "IX_LikeReviews_ReviewClassId",
                table: "LikeReviews");

            migrationBuilder.DropColumn(
                name: "ReviewClassId",
                table: "LikeReviews");

            migrationBuilder.AddColumn<int>(
                name: "LikedClassReviewReviewClassId",
                table: "LikeReviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "LikeReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LikeReviews_LikedClassReviewReviewClassId",
                table: "LikeReviews",
                column: "LikedClassReviewReviewClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeReviews_ReviewClasses_LikedClassReviewReviewClassId",
                table: "LikeReviews",
                column: "LikedClassReviewReviewClassId",
                principalTable: "ReviewClasses",
                principalColumn: "ReviewClassId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
