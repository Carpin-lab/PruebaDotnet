using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaDotnet.Migrations
{
    /// <inheritdoc />
    public partial class relaciondemuchosaunoentreusuarioytareas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_userid",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_userid",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Tasks");
        }
    }
}
