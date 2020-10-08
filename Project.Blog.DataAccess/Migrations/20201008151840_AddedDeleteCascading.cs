using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Blog.DataAccess.Migrations
{
    public partial class AddedDeleteCascading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Sharings_SharingId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sharings_Categories_CategoryId",
                table: "Sharings");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Sharings_SharingId",
                table: "Comments",
                column: "SharingId",
                principalTable: "Sharings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sharings_Categories_CategoryId",
                table: "Sharings",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Sharings_SharingId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sharings_Categories_CategoryId",
                table: "Sharings");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Sharings_SharingId",
                table: "Comments",
                column: "SharingId",
                principalTable: "Sharings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sharings_Categories_CategoryId",
                table: "Sharings",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
