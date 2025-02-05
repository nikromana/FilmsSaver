using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsSaverDbContext.Migrations
{
    /// <inheritdoc />
    public partial class filmsWasMadeAsList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Films_SavedFilmsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SavedFilmsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SavedFilmsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Films",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_UserId",
                table: "Films",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_AspNetUsers_UserId",
                table: "Films",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_AspNetUsers_UserId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_UserId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "SavedFilmsId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SavedFilmsId",
                table: "AspNetUsers",
                column: "SavedFilmsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Films_SavedFilmsId",
                table: "AspNetUsers",
                column: "SavedFilmsId",
                principalTable: "Films",
                principalColumn: "Id");
        }
    }
}
