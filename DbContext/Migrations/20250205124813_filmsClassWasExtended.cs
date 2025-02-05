using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsSaverDbContext.Migrations
{
    /// <inheritdoc />
    public partial class filmsClassWasExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearOfFilm",
                table: "Films",
                newName: "Year");

            migrationBuilder.AddColumn<string>(
                name: "Actors",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Awards",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rated",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Released",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actors",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Awards",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Plot",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Rated",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Released",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Films",
                newName: "YearOfFilm");
        }
    }
}
