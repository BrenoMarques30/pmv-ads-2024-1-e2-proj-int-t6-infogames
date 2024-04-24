using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoGames.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lojas",
                keyColumn: "Id",
                keyValue: "72103ceb-ffc4-4f49-b11f-2189221b636a");

            migrationBuilder.CreateTable(
                name: "RequisitosLinux",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Minimum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommended = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosLinux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosLinux_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitosMac",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Minimum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommended = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosMac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosMac_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitosPC",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Minimum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommended = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosPC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosPC_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lojas",
                columns: new[] { "Id", "ChaveApi", "Logo", "Nome", "Url" },
                values: new object[] { "1d5f4004-1ff0-4714-8d7f-257a70916dac", "123456", "https://upload.wikimedia.org/wikipedia/commons/8/83/Steam_icon_logo.svg", "Steam", "https://store.steampowered.com/" });

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosLinux_IdDetalhesJogo",
                table: "RequisitosLinux",
                column: "IdDetalhesJogo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosMac_IdDetalhesJogo",
                table: "RequisitosMac",
                column: "IdDetalhesJogo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosPC_IdDetalhesJogo",
                table: "RequisitosPC",
                column: "IdDetalhesJogo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequisitosLinux");

            migrationBuilder.DropTable(
                name: "RequisitosMac");

            migrationBuilder.DropTable(
                name: "RequisitosPC");

            migrationBuilder.DeleteData(
                table: "Lojas",
                keyColumn: "Id",
                keyValue: "1d5f4004-1ff0-4714-8d7f-257a70916dac");

            migrationBuilder.InsertData(
                table: "Lojas",
                columns: new[] { "Id", "ChaveApi", "Logo", "Nome", "Url" },
                values: new object[] { "72103ceb-ffc4-4f49-b11f-2189221b636a", "123456", "https://upload.wikimedia.org/wikipedia/commons/8/83/Steam_icon_logo.svg", "Steam", "https://store.steampowered.com/" });
        }
    }
}
