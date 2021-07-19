using Microsoft.EntityFrameworkCore.Migrations;

namespace LogosoftProjekat.Migrations
{
    public partial class usersToDo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersToDo",
                columns: table => new
                {
                    UserToDoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ToDoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToDo", x => x.UserToDoId);
                    table.ForeignKey(
                        name: "FK_UsersToDo_ToDo_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDo",
                        principalColumn: "TodoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsersToDo_Identity_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersToDo_ToDoId",
                table: "UsersToDo",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToDo_UserId",
                table: "UsersToDo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersToDo");
        }
    }
}
