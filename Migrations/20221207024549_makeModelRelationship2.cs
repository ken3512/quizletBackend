using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetBackend.Migrations
{
    /// <inheritdoc />
    public partial class makeModelRelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "NoteSets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NoteSets_UserId",
                table: "NoteSets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteSets_Users_UserId",
                table: "NoteSets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteSets_Users_UserId",
                table: "NoteSets");

            migrationBuilder.DropIndex(
                name: "IX_NoteSets_UserId",
                table: "NoteSets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NoteSets");
        }
    }
}
