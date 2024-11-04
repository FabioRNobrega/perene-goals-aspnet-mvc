using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace perene_goals_dotnet.Migrations
{
    public partial class GoalsSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoalsLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalsLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoalsLists_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalsListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_GoalsLists_GoalsListId",
                        column: x => x.GoalsListId,
                        principalTable: "GoalsLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoalsListVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalsListId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VotesUp = table.Column<int>(type: "int", nullable: false),
                    VotesDown = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalsListVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoalsListVotes_GoalsLists_GoalsListId",
                        column: x => x.GoalsListId,
                        principalTable: "GoalsLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoalsSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalsSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoalsSteps_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_GoalsListId",
                table: "Goals",
                column: "GoalsListId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalsLists_UserId1",
                table: "GoalsLists",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_GoalsListVotes_GoalsListId",
                table: "GoalsListVotes",
                column: "GoalsListId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalsListVotes_UserId_GoalsListId",
                table: "GoalsListVotes",
                columns: new[] { "UserId", "GoalsListId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoalsSteps_GoalId",
                table: "GoalsSteps",
                column: "GoalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalsListVotes");

            migrationBuilder.DropTable(
                name: "GoalsSteps");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "GoalsLists");
        }
    }
}
