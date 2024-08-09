using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeEngineerBlogServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsTags_Blogs_BlogId",
                table: "BlogsTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogsTags_Tags_TagId",
                table: "BlogsTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Informations_Link_LinkId",
                table: "Informations");

            migrationBuilder.DropIndex(
                name: "IX_Informations_LinkId",
                table: "Informations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogCategories",
                table: "BlogCategories");

            migrationBuilder.DropIndex(
                name: "IX_BlogCategories_BlogId",
                table: "BlogCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogsTags",
                table: "BlogsTags");

            migrationBuilder.DropIndex(
                name: "IX_BlogsTags_BlogId",
                table: "BlogsTags");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "Informations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BlogsTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BlogsTags");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BlogsTags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BlogsTags");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BlogsTags");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BlogsTags");

            migrationBuilder.RenameTable(
                name: "BlogsTags",
                newName: "BlogTags");

            migrationBuilder.RenameIndex(
                name: "IX_BlogsTags_TagId",
                table: "BlogTags",
                newName: "IX_BlogTags_TagId");

            migrationBuilder.AddColumn<string>(
                name: "GithubUrl",
                table: "Informations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Informations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedinUrl",
                table: "Informations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "XUrl",
                table: "Informations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogCategories",
                table: "BlogCategories",
                columns: new[] { "BlogId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogTags",
                table: "BlogTags",
                columns: new[] { "BlogId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTags_Blogs_BlogId",
                table: "BlogTags",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTags_Tags_TagId",
                table: "BlogTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogTags_Blogs_BlogId",
                table: "BlogTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTags_Tags_TagId",
                table: "BlogTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogCategories",
                table: "BlogCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogTags",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "GithubUrl",
                table: "Informations");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Informations");

            migrationBuilder.DropColumn(
                name: "LinkedinUrl",
                table: "Informations");

            migrationBuilder.DropColumn(
                name: "XUrl",
                table: "Informations");

            migrationBuilder.RenameTable(
                name: "BlogTags",
                newName: "BlogsTags");

            migrationBuilder.RenameIndex(
                name: "IX_BlogTags_TagId",
                table: "BlogsTags",
                newName: "IX_BlogsTags_TagId");

            migrationBuilder.AddColumn<Guid>(
                name: "LinkId",
                table: "Informations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BlogCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BlogCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BlogCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BlogCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BlogCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BlogCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BlogsTags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BlogsTags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BlogsTags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BlogsTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BlogsTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BlogsTags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogCategories",
                table: "BlogCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogsTags",
                table: "BlogsTags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Informations_LinkId",
                table: "Informations",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_BlogId",
                table: "BlogCategories",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsTags_BlogId",
                table: "BlogsTags",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsTags_Blogs_BlogId",
                table: "BlogsTags",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsTags_Tags_TagId",
                table: "BlogsTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Informations_Link_LinkId",
                table: "Informations",
                column: "LinkId",
                principalTable: "Link",
                principalColumn: "Id");
        }
    }
}
