using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicPlatform.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Playlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Users_ArtistId",
                table: "Playlist");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Playlist",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlist_ArtistId",
                table: "Playlist",
                newName: "IX_Playlist_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Users_UserId",
                table: "Playlist",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Users_UserId",
                table: "Playlist");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Playlist",
                newName: "ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlist_UserId",
                table: "Playlist",
                newName: "IX_Playlist_ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Users_ArtistId",
                table: "Playlist",
                column: "ArtistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
