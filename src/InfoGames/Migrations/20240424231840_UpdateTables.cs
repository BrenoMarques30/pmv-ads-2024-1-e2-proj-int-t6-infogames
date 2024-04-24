using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoGames.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_DetalhesJogos_DetalhesId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_DetalhesId",
                table: "Jogos");

            migrationBuilder.DeleteData(
                table: "Lojas",
                keyColumn: "Id",
                keyValue: "d58f4180-8360-4240-a006-3eb24b7cd005");

            migrationBuilder.DropColumn(
                name: "DetalhesId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "SteamAppId",
                table: "DetalhesJogos");

            migrationBuilder.AddColumn<string>(
                name: "LojaId",
                table: "Jogos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppId",
                table: "DetalhesJogos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControllerSupport",
                table: "DetalhesJogos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Developers",
                table: "DetalhesJogos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dlc",
                table: "DetalhesJogos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdJogo",
                table: "DetalhesJogos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LegalNotice",
                table: "DetalhesJogos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Packages",
                table: "DetalhesJogos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Publishers",
                table: "DetalhesJogos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecommendationsTotal",
                table: "DetalhesJogos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JogosCompletos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullGameAppId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogosCompletos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogosCompletos_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lojas",
                columns: new[] { "Id", "ChaveApi", "Logo", "Nome", "Url" },
                values: new object[] { "72103ceb-ffc4-4f49-b11f-2189221b636a", "123456", "https://upload.wikimedia.org/wikipedia/commons/8/83/Steam_icon_logo.svg", "Steam", "https://store.steampowered.com/" });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_LojaId",
                table: "Jogos",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalhesJogos_IdJogo",
                table: "DetalhesJogos",
                column: "IdJogo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JogosCompletos_IdDetalhesJogo",
                table: "JogosCompletos",
                column: "IdDetalhesJogo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalhesJogos_Jogos_IdJogo",
                table: "DetalhesJogos",
                column: "IdJogo",
                principalTable: "Jogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Lojas_LojaId",
                table: "Jogos",
                column: "LojaId",
                principalTable: "Lojas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalhesJogos_Jogos_IdJogo",
                table: "DetalhesJogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Lojas_LojaId",
                table: "Jogos");

            migrationBuilder.DropTable(
                name: "JogosCompletos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_LojaId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_DetalhesJogos_IdJogo",
                table: "DetalhesJogos");

            migrationBuilder.DeleteData(
                table: "Lojas",
                keyColumn: "Id",
                keyValue: "72103ceb-ffc4-4f49-b11f-2189221b636a");

            migrationBuilder.DropColumn(
                name: "LojaId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "AppId",
                table: "DetalhesJogos");

            migrationBuilder.DropColumn(
                name: "ControllerSupport",
                table: "DetalhesJogos");

            migrationBuilder.DropColumn(
                name: "Developers",
                table: "DetalhesJogos");

            migrationBuilder.DropColumn(
                name: "Dlc",
                table: "DetalhesJogos");

            migrationBuilder.DropColumn(
                name: "IdJogo",
                table: "DetalhesJogos");

            migrationBuilder.DropColumn(
                name: "LegalNotice",
                table: "DetalhesJogos");

            migrationBuilder.DropColumn(
                name: "Packages",
                table: "DetalhesJogos");

            migrationBuilder.DropColumn(
                name: "Publishers",
                table: "DetalhesJogos");

            migrationBuilder.DropColumn(
                name: "RecommendationsTotal",
                table: "DetalhesJogos");

            migrationBuilder.AddColumn<string>(
                name: "DetalhesId",
                table: "Jogos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SteamAppId",
                table: "DetalhesJogos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Lojas",
                columns: new[] { "Id", "ChaveApi", "Logo", "Nome", "Url" },
                values: new object[] { "d58f4180-8360-4240-a006-3eb24b7cd005", "123456", "https://upload.wikimedia.org/wikipedia/commons/8/83/Steam_icon_logo.svg", "Steam", "https://store.steampowered.com/" });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_DetalhesId",
                table: "Jogos",
                column: "DetalhesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_DetalhesJogos_DetalhesId",
                table: "Jogos",
                column: "DetalhesId",
                principalTable: "DetalhesJogos",
                principalColumn: "Id");
        }
    }
}
