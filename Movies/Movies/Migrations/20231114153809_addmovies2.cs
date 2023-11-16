using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Migrations
{
    public partial class addmovies2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Generes_genreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GID",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "Movies",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_genreId",
                table: "Movies",
                newName: "IX_Movies_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Generes_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Generes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Generes_GenreId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Movies",
                newName: "genreId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                newName: "IX_Movies_genreId");

            migrationBuilder.AddColumn<byte>(
                name: "GID",
                table: "Movies",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Generes_genreId",
                table: "Movies",
                column: "genreId",
                principalTable: "Generes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
