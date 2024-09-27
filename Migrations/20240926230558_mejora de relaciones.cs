using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaDotnet.Migrations
{
    /// <inheritdoc />
    public partial class mejoraderelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_userid",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_userid",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_user_id",
                table: "Tasks",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_user_id",
                table: "Tasks",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_user_id",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_user_id",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_userid",
                table: "Tasks",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_userid",
                table: "Tasks",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
