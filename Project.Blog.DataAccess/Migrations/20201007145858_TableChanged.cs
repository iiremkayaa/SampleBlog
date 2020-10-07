using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Blog.DataAccess.Migrations
{
    public partial class TableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CommentOwnerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentOwnerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentOwnerId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CommentOwnerId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentOwnerId",
                table: "Comments",
                column: "CommentOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CommentOwnerId",
                table: "Comments",
                column: "CommentOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
