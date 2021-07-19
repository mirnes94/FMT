using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogosoftProjekat.Migrations
{
    public partial class AddToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizationToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    LoggedTime = table.Column<DateTime>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorizationToken_Identity_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationToken_UserId",
                table: "AuthorizationToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizationToken");
        }
    }
}
