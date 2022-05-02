using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaporGames.Migrations
{
    public partial class PopulateGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Games(Name,Description,Price,MetaCritic,ImageUrl,ImageThumb,ReleaseDate,GenreId)" +
                "VALUES('The Witcher','O bruxo ta bolado','50','100','https://cdn.akamai.steamstatic.com/steam/subs/124923/capsule_sm_120.jpg?t=1646333574','https://cdn.akamai.steamstatic.com/steam/subs/124923/capsule_sm_120.jpg?t=1646333574','21/06/2016',1)");
            migrationBuilder.Sql("INSERT INTO Games(Name,Description,Price,MetaCritic,ImageUrl,ImageThumb,ReleaseDate,GenreId)" +
                "VALUES('Call of Duty','Tiro pra todo lado','10','70','https://cdn.akamai.steamstatic.com/steam/subs/124923/capsule_sm_120.jpg?t=1646333574','https://cdn.akamai.steamstatic.com/steam/subs/124923/capsule_sm_120.jpg?t=1646333574','12/06/2012',2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Games");
        }
    }
}
