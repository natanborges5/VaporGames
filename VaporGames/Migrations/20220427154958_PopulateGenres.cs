using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaporGames.Migrations
{
    public partial class PopulateGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres(Name,Description)" +
                "VALUES('RPG','JOGOS DE RPG')");
            migrationBuilder.Sql("INSERT INTO Genres(Name,Description)" +
                "VALUES('FPS','JOGOS DE FPS')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genres");
        }
    }
}
