using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class genrePropertyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GenreId",
                table: "Games");
        }
    }
}
