using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicPlatform.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Single : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Singles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Singles_ArtistId",
                table: "Singles",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Singles_Users_ArtistId",
                table: "Singles",
                column: "ArtistId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Singles_Users_ArtistId",
                table: "Singles");

            migrationBuilder.DropIndex(
                name: "IX_Singles_ArtistId",
                table: "Singles");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Singles");
        }
    }
}
