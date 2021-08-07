using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessProject.Migrations
{
    public partial class Community : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.CreateTable(
                name: "FavoriteClasses",
                columns: table => new
                {
                    FavoriteClassId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteClasses", x => x.FavoriteClassId);
                    table.ForeignKey(
                        name: "FK_FavoriteClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteClasses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteInstructors",
                columns: table => new
                {
                    FavoriteInstructorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    InstructorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteInstructors", x => x.FavoriteInstructorId);
                    table.ForeignKey(
                        name: "FK_FavoriteInstructors_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteInstructors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LikeClasses",
                columns: table => new
                {
                    LikeClassId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeClasses", x => x.LikeClassId);
                    table.ForeignKey(
                        name: "FK_LikeClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeClasses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewClasses",
                columns: table => new
                {
                    ReviewClassId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewClasses", x => x.ReviewClassId);
                    table.ForeignKey(
                        name: "FK_ReviewClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewClasses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewInstructors",
                columns: table => new
                {
                    ReviewInstructorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    InstructorId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewInstructors", x => x.ReviewInstructorId);
                    table.ForeignKey(
                        name: "FK_ReviewInstructors_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewInstructors_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewInstructors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LikeReviews",
                columns: table => new
                {
                    LikeReviewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    ReviewId = table.Column<int>(nullable: false),
                    LikedClassReviewReviewClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeReviews", x => x.LikeReviewId);
                    table.ForeignKey(
                        name: "FK_LikeReviews_ReviewClasses_LikedClassReviewReviewClassId",
                        column: x => x.LikedClassReviewReviewClassId,
                        principalTable: "ReviewClasses",
                        principalColumn: "ReviewClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LikeReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteClasses_ClassId",
                table: "FavoriteClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteClasses_UserId",
                table: "FavoriteClasses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteInstructors_InstructorId",
                table: "FavoriteInstructors",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteInstructors_UserId",
                table: "FavoriteInstructors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeClasses_ClassId",
                table: "LikeClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeClasses_UserId",
                table: "LikeClasses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeReviews_LikedClassReviewReviewClassId",
                table: "LikeReviews",
                column: "LikedClassReviewReviewClassId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeReviews_UserId",
                table: "LikeReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewClasses_ClassId",
                table: "ReviewClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewClasses_UserId",
                table: "ReviewClasses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewInstructors_ClassId",
                table: "ReviewInstructors",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewInstructors_InstructorId",
                table: "ReviewInstructors",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewInstructors_UserId",
                table: "ReviewInstructors",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteClasses");

            migrationBuilder.DropTable(
                name: "FavoriteInstructors");

            migrationBuilder.DropTable(
                name: "LikeClasses");

            migrationBuilder.DropTable(
                name: "LikeReviews");

            migrationBuilder.DropTable(
                name: "ReviewInstructors");

            migrationBuilder.DropTable(
                name: "ReviewClasses");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClassId",
                table: "Reviews",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }
    }
}
