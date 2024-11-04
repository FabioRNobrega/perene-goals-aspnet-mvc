using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace perene_goals_dotnet.Migrations
{
    public partial class UpdateUserIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalsLists_AspNetUsers_UserId1",
                table: "GoalsLists");

            migrationBuilder.DropIndex(
                name: "IX_GoalsLists_UserId1",
                table: "GoalsLists");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "GoalsLists");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GoalsListVotes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GoalsLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_GoalsLists_UserId",
                table: "GoalsLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoalsLists_AspNetUsers_UserId",
                table: "GoalsLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalsLists_AspNetUsers_UserId",
                table: "GoalsLists");

            migrationBuilder.DropIndex(
                name: "IX_GoalsLists_UserId",
                table: "GoalsLists");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GoalsListVotes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GoalsLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "GoalsLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoalsLists_UserId1",
                table: "GoalsLists",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GoalsLists_AspNetUsers_UserId1",
                table: "GoalsLists",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
