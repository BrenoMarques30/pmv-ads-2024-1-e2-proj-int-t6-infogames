using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoGames.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lojas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChaveApi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeDeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContaSuspensa = table.Column<bool>(type: "bit", nullable: false),
                    ContaRestrita = table.Column<bool>(type: "bit", nullable: false),
                    SteamIdVinculado = table.Column<int>(type: "int", nullable: false),
                    EmailVerificado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LojaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Lojas_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Lojas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalhesJogos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdJogo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecomendacaoEtaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EGratuito = table.Column<bool>(type: "bit", nullable: true),
                    SuporteAControle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoDetalhada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SobreOJogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoCurta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinguasDisponiveis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnailv5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermosDeUso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDeLikes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemBackground = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemBackgroundRaw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dlc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desenvolvedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Editor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pacotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalhesJogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalhesJogos_Jogos_IdJogo",
                        column: x => x.IdJogo,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassificacoesIndicativas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloquearPorIdade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecomendacaoEtaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificacoesIndicativas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassificacoesIndicativas_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Conquistas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conquistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conquistas_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DatasDeLancamento",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstaChegando = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatasDeLancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatasDeLancamento_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Demos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Appid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demos_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DescritoresDeConteudo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescritoresDeConteudo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescritoresDeConteudo_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalhesDosPrecos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Moeda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoInicial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoFinal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescontoPorcentagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoInicialFormatado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoFinalFormatado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalhesDosPrecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalhesDosPrecos_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destacar = table.Column<bool>(type: "bit", nullable: false),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmes_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdGenero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generos_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GruposDePacotes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelecaoDeTexto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalvarTexto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExibirTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EAssinaturaRecorrente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposDePacotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GruposDePacotes_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InformacoesDeSuporte",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacoesDeSuporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformacoesDeSuporte_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JogosCompletos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdJogoCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogosCompletos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogosCompletos_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Metacriticas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pontuacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metacriticas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metacriticas_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plataformas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Windows = table.Column<bool>(type: "bit", nullable: true),
                    Mac = table.Column<bool>(type: "bit", nullable: true),
                    Linux = table.Column<bool>(type: "bit", nullable: true),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataformas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plataformas_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequisitosLinux",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Minimo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recomendado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosLinux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosLinux_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequisitosMac",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Minimo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recomendado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosMac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosMac_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequisitosPC",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Minimo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recomendado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosPC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosPC_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Screenshots",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UrlThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImagemCompleta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDetalhesJogo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenshots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenshots_DetalhesJogos_IdDetalhesJogo",
                        column: x => x.IdDetalhesJogo,
                        principalTable: "DetalhesJogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Destaques",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdConquista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdConquistas = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlIcone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destaques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destaques_Conquistas_IdConquistas",
                        column: x => x.IdConquistas,
                        principalTable: "Conquistas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mp4s",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdFilme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    _480 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Max = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mp4s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mp4s_Filmes_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Webms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdFilme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    _480 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Max = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Webms_Filmes_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdGrupoDePacote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupoDePacoteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PacoteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorcentagemDoDescontoTexto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorcentagemDoDesconto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpcaoTexto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpcaoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObtidaGratuitamente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicencaEGratuita = table.Column<bool>(type: "bit", nullable: true),
                    PrecoComDesconto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacotes_GruposDePacotes_GrupoDePacoteId",
                        column: x => x.GrupoDePacoteId,
                        principalTable: "GruposDePacotes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Lojas",
                columns: new[] { "Id", "ChaveApi", "Logo", "Nome", "Url" },
                values: new object[] { "f16ebb03-9513-43e4-a9e4-7043b970d7f7", "", "https://upload.wikimedia.org/wikipedia/commons/8/83/Steam_icon_logo.svg", "Steam", "https://store.steampowered.com/" });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdDetalhesJogo",
                table: "Categorias",
                column: "IdDetalhesJogo");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificacoesIndicativas_IdDetalhesJogo",
                table: "ClassificacoesIndicativas",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistas_IdDetalhesJogo",
                table: "Conquistas",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DatasDeLancamento_IdDetalhesJogo",
                table: "DatasDeLancamento",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Demos_IdDetalhesJogo",
                table: "Demos",
                column: "IdDetalhesJogo");

            migrationBuilder.CreateIndex(
                name: "IX_DescritoresDeConteudo_IdDetalhesJogo",
                table: "DescritoresDeConteudo",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Destaques_IdConquistas",
                table: "Destaques",
                column: "IdConquistas");

            migrationBuilder.CreateIndex(
                name: "IX_DetalhesDosPrecos_IdDetalhesJogo",
                table: "DetalhesDosPrecos",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetalhesJogos_IdJogo",
                table: "DetalhesJogos",
                column: "IdJogo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_IdDetalhesJogo",
                table: "Filmes",
                column: "IdDetalhesJogo");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_IdDetalhesJogo",
                table: "Generos",
                column: "IdDetalhesJogo");

            migrationBuilder.CreateIndex(
                name: "IX_GruposDePacotes_IdDetalhesJogo",
                table: "GruposDePacotes",
                column: "IdDetalhesJogo");

            migrationBuilder.CreateIndex(
                name: "IX_InformacoesDeSuporte_IdDetalhesJogo",
                table: "InformacoesDeSuporte",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_LojaId",
                table: "Jogos",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_JogosCompletos_IdDetalhesJogo",
                table: "JogosCompletos",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Metacriticas_IdDetalhesJogo",
                table: "Metacriticas",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mp4s_IdFilme",
                table: "Mp4s",
                column: "IdFilme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_GrupoDePacoteId",
                table: "Pacotes",
                column: "GrupoDePacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Plataformas_IdDetalhesJogo",
                table: "Plataformas",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosLinux_IdDetalhesJogo",
                table: "RequisitosLinux",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosMac_IdDetalhesJogo",
                table: "RequisitosMac",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosPC_IdDetalhesJogo",
                table: "RequisitosPC",
                column: "IdDetalhesJogo",
                unique: true,
                filter: "[IdDetalhesJogo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Screenshots_IdDetalhesJogo",
                table: "Screenshots",
                column: "IdDetalhesJogo");

            migrationBuilder.CreateIndex(
                name: "IX_Webms_IdFilme",
                table: "Webms",
                column: "IdFilme",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ClassificacoesIndicativas");

            migrationBuilder.DropTable(
                name: "DatasDeLancamento");

            migrationBuilder.DropTable(
                name: "Demos");

            migrationBuilder.DropTable(
                name: "DescritoresDeConteudo");

            migrationBuilder.DropTable(
                name: "Destaques");

            migrationBuilder.DropTable(
                name: "DetalhesDosPrecos");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "InformacoesDeSuporte");

            migrationBuilder.DropTable(
                name: "JogosCompletos");

            migrationBuilder.DropTable(
                name: "Metacriticas");

            migrationBuilder.DropTable(
                name: "Mp4s");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Plataformas");

            migrationBuilder.DropTable(
                name: "RequisitosLinux");

            migrationBuilder.DropTable(
                name: "RequisitosMac");

            migrationBuilder.DropTable(
                name: "RequisitosPC");

            migrationBuilder.DropTable(
                name: "Screenshots");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Webms");

            migrationBuilder.DropTable(
                name: "Conquistas");

            migrationBuilder.DropTable(
                name: "GruposDePacotes");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "DetalhesJogos");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Lojas");
        }
    }
}
