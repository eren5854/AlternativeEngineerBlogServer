using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeEngineerBlogServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Link_LinkId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LinkId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Link",
                newName: "LogoName");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Link",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Contacts",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Contacts",
                type: "varchar(MAX)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Contacts",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Contacts",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_AppUserId",
                table: "Link",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_Users_AppUserId",
                table: "Link",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_Users_AppUserId",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Link_AppUserId",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "LogoName",
                table: "Link",
                newName: "Logo");

            migrationBuilder.AddColumn<Guid>(
                name: "LinkId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LinkId",
                table: "Users",
                column: "LinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Link_LinkId",
                table: "Users",
                column: "LinkId",
                principalTable: "Link",
                principalColumn: "Id");
        }
    }
}
