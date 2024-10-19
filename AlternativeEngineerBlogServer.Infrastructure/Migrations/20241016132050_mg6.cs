using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeEngineerBlogServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "varchar(1000)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "MainCommentId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MainCommentId",
                table: "Comments",
                column: "MainCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_MainCommentId",
                table: "Comments",
                column: "MainCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_MainCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MainCommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MainCommentId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 500);
        }
    }
}
