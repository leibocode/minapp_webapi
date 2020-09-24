using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _0_Mapping_Welfare_API.Migrations
{
    public partial class addEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Crated",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "WechatUserOpenId",
                table: "WechatUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WechatUserOpenId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_WechatUsers_WechatUserOpenId",
                table: "WechatUsers",
                column: "WechatUserOpenId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WechatUserOpenId",
                table: "Comments",
                column: "WechatUserOpenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_WechatUsers_WechatUserOpenId",
                table: "Comments",
                column: "WechatUserOpenId",
                principalTable: "WechatUsers",
                principalColumn: "OpenId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WechatUsers_WechatUsers_WechatUserOpenId",
                table: "WechatUsers",
                column: "WechatUserOpenId",
                principalTable: "WechatUsers",
                principalColumn: "OpenId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_WechatUsers_WechatUserOpenId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_WechatUsers_WechatUsers_WechatUserOpenId",
                table: "WechatUsers");

            migrationBuilder.DropIndex(
                name: "IX_WechatUsers_WechatUserOpenId",
                table: "WechatUsers");

            migrationBuilder.DropIndex(
                name: "IX_Comments_WechatUserOpenId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "WechatUserOpenId",
                table: "WechatUsers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "WechatUserOpenId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Activities");

            migrationBuilder.AddColumn<DateTime>(
                name: "Crated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
