using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoGames.Migrations
{
    /// <inheritdoc />
    public partial class SeedLojaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lojas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChaveApi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Lojas",
                columns: new[] { "Id", "ChaveApi", "Logo", "Nome", "Url" },
                values: new object[] { "1", "123456", "https://upload.wikimedia.org/wikipedia/commons/8/83/Steam_icon_logo.svg", "Steam", "https://store.steampowered.com/" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lojas");
        }
    }
}
