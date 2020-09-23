using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _0_Mapping_Welfare_API.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Region = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    Give = table.Column<int>(nullable: false),
                    Astate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Region = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    orgState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Crated = table.Column<DateTime>(nullable: false),
                    CommentText = table.Column<string>(nullable: true),
                    ActivityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WechatUsers",
                columns: table => new
                {
                    OpenId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PIDNumber = table.Column<string>(nullable: true),
                    Region = table.Column<int>(nullable: false),
                    OrganizationsId = table.Column<Guid>(nullable: true),
                    OrgId = table.Column<Guid>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WechatUsers", x => x.OpenId);
                    table.ForeignKey(
                        name: "FK_WechatUsers_Organizations_OrganizationsId",
                        column: x => x.OrganizationsId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ActivityId",
                table: "Comments",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_WechatUsers_OrganizationsId",
                table: "WechatUsers",
                column: "OrganizationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "WechatUsers");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
