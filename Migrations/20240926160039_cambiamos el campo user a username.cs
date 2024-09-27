using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaDotnet.Migrations
{
    /// <inheritdoc />
    public partial class cambiamoselcampouserausername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user",
                table: "Users",
                newName: "username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "user");
        }
    }
}
