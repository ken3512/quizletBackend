using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetBackend.Migrations
{
    /// <inheritdoc />
    public partial class makeModelRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoteSetId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_NoteSetId",
                table: "Cards",
                column: "NoteSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_NoteSets_NoteSetId",
                table: "Cards",
                column: "NoteSetId",
                principalTable: "NoteSets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_NoteSets_NoteSetId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_NoteSetId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "NoteSetId",
                table: "Cards");
        }
    }
}
