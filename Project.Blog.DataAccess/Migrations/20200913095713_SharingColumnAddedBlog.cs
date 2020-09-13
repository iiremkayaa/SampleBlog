using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Blog.DataAccess.Migrations
{
    public partial class SharingColumnAddedBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SharingDate",
                table: "Sharings",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SharingDate",
                table: "Sharings");
        }
    }
}
