using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsSaverDbContext.Migrations
{
    /// <inheritdoc />
    public partial class filmsAllowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Films_SavedFilmsId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SavedFilmsId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Films_SavedFilmsId",
                table: "AspNetUsers",
                column: "SavedFilmsId",
                principalTable: "Films",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Films_SavedFilmsId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SavedFilmsId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Films_SavedFilmsId",
                table: "AspNetUsers",
                column: "SavedFilmsId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
