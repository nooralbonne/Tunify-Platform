using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class CreateArtistTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaylistsId1",
                table: "PlaylistSongs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SongsId1",
                table: "PlaylistSongs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    PlaylistsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    PlaylistsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.PlaylistsId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_PlaylistsId1",
                table: "PlaylistSongs",
                column: "PlaylistsId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_SongsId1",
                table: "PlaylistSongs",
                column: "SongsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Playlists_PlaylistsId1",
                table: "PlaylistSongs",
                column: "PlaylistsId1",
                principalTable: "Playlists",
                principalColumn: "PlaylistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Songs_SongsId1",
                table: "PlaylistSongs",
                column: "SongsId1",
                principalTable: "Songs",
                principalColumn: "SongsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Playlists_PlaylistsId1",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Songs_SongsId1",
                table: "PlaylistSongs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_PlaylistsId1",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_SongsId1",
                table: "PlaylistSongs");

            migrationBuilder.DropColumn(
                name: "PlaylistsId1",
                table: "PlaylistSongs");

            migrationBuilder.DropColumn(
                name: "SongsId1",
                table: "PlaylistSongs");
        }
    }
}
