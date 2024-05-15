﻿// <auto-generated />
using System;
using InfoGames.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfoGames.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InfoGames.Models.Categoria", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("InfoGames.Models.ClassificacaoIndicativa", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BloquearPorIdade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecomendacaoEtaria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("ClassificacoesIndicativas");
                });

            modelBuilder.Entity("InfoGames.Models.Conquista", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Total")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("Conquistas");
                });

            modelBuilder.Entity("InfoGames.Models.DataDeLancamento", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaChegando")
                        .HasColumnType("bit");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("DatasDeLancamento");
                });

            modelBuilder.Entity("InfoGames.Models.Demonstracoes", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Appid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo");

                    b.ToTable("Demos");
                });

            modelBuilder.Entity("InfoGames.Models.DescritorDeConteudo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ids")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notas")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("DescritoresDeConteudo");
                });

            modelBuilder.Entity("InfoGames.Models.Destaque", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdConquista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdConquistas")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlIcone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdConquistas");

                    b.ToTable("Destaques");
                });

            modelBuilder.Entity("InfoGames.Models.DetalhesDoPreco", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DescontoPorcentagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Moeda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrecoFinal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrecoFinalFormatado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrecoInicial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrecoInicialFormatado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("DetalhesDosPrecos");
                });

            modelBuilder.Entity("InfoGames.Models.DetalhesJogoModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoCurta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoDetalhada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desenvolvedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dlc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("EGratuito")
                        .HasColumnType("bit");

                    b.Property<string>("Editor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdJogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImagemBackground")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemBackgroundRaw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemPrincipal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinguasDisponiveis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDeLikes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pacotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecomendacaoEtaria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreOJogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuporteAControle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TermosDeUso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnailv5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdJogo")
                        .IsUnique();

                    b.ToTable("DetalhesJogos");
                });

            modelBuilder.Entity("InfoGames.Models.Filme", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Destacar")
                        .HasColumnType("bit");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("InfoGames.Models.Generos", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdGenero")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("InfoGames.Models.GrupoDePacote", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EAssinaturaRecorrente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExibirTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalvarTexto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelecaoDeTexto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo");

                    b.ToTable("GruposDePacotes");
                });

            modelBuilder.Entity("InfoGames.Models.InformacaoDeSuporte", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("InformacoesDeSuporte");
                });

            modelBuilder.Entity("InfoGames.Models.JogoCompleto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdJogoCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("JogosCompletos");
                });

            modelBuilder.Entity("InfoGames.Models.JogoModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LojaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LojaId");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("InfoGames.Models.LojaModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChaveApi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lojas");

                    b.HasData(
                        new
                        {
                            Id = "fcd084a2-1cb8-4c1e-9c48-4b05c60b6d3f",
                            ChaveApi = "",
                            Logo = "https://upload.wikimedia.org/wikipedia/commons/8/83/Steam_icon_logo.svg",
                            Nome = "Steam",
                            Url = "https://store.steampowered.com/"
                        });
                });

            modelBuilder.Entity("InfoGames.Models.Metacritica", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Pontuacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("Metacriticas");
                });

            modelBuilder.Entity("InfoGames.Models.Mp4", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdFilme")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_480")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdFilme")
                        .IsUnique();

                    b.ToTable("Mp4s");
                });

            modelBuilder.Entity("InfoGames.Models.NoticiaModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsExternalUrl")
                        .HasColumnType("bit");

                    b.Property<string>("JogoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NomeNoFeed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JogoId");

                    b.ToTable("Noticias");
                });

            modelBuilder.Entity("InfoGames.Models.Pacote", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GrupoDePacoteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdGrupoDePacote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("LicencaEGratuita")
                        .HasColumnType("bit");

                    b.Property<string>("ObtidaGratuitamente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpcaoDescricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpcaoTexto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PacoteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PorcentagemDoDesconto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PorcentagemDoDescontoTexto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrecoComDesconto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoDePacoteId");

                    b.ToTable("Pacotes");
                });

            modelBuilder.Entity("InfoGames.Models.Plataforma", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("Linux")
                        .HasColumnType("bit");

                    b.Property<bool?>("Mac")
                        .HasColumnType("bit");

                    b.Property<bool?>("Windows")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("Plataformas");
                });

            modelBuilder.Entity("InfoGames.Models.RequisitoLinux", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Minimo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recomendado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("RequisitosLinux");
                });

            modelBuilder.Entity("InfoGames.Models.RequisitoMac", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Minimo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recomendado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("RequisitosMac");
                });

            modelBuilder.Entity("InfoGames.Models.RequisitoPC", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Minimo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recomendado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo")
                        .IsUnique()
                        .HasFilter("[IdDetalhesJogo] IS NOT NULL");

                    b.ToTable("RequisitosPC");
                });

            modelBuilder.Entity("InfoGames.Models.Screenshot", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDetalhesJogo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UrlImagemCompleta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlThumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDetalhesJogo");

                    b.ToTable("Screenshots");
                });

            modelBuilder.Entity("InfoGames.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ContaRestrita")
                        .HasColumnType("bit")
                        .HasColumnName("ContaRestrita");

                    b.Property<bool>("ContaSuspensa")
                        .HasColumnType("bit")
                        .HasColumnName("ContaSuspensa");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<bool>("EmailVerificado")
                        .HasColumnType("bit")
                        .HasColumnName("EmailVerificado");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<string>("NomeDeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeDeUsuario");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Senha");

                    b.Property<int>("SteamIdVinculado")
                        .HasColumnType("int")
                        .HasColumnName("SteamIdVinculado");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Token");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("InfoGames.Models.Webm", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdFilme")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_480")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdFilme")
                        .IsUnique();

                    b.ToTable("Webms");
                });

            modelBuilder.Entity("InfoGames.Models.Categoria", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithMany("Categoria")
                        .HasForeignKey("IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.ClassificacaoIndicativa", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("Classificacao")
                        .HasForeignKey("InfoGames.Models.ClassificacaoIndicativa", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.Conquista", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("Conquista")
                        .HasForeignKey("InfoGames.Models.Conquista", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.DataDeLancamento", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("DataDeLancamento")
                        .HasForeignKey("InfoGames.Models.DataDeLancamento", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.Demonstracoes", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithMany("Demonstracao")
                        .HasForeignKey("IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.DescritorDeConteudo", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("DescritorDeConteudo")
                        .HasForeignKey("InfoGames.Models.DescritorDeConteudo", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.Destaque", b =>
                {
                    b.HasOne("InfoGames.Models.Conquista", "Conquista")
                        .WithMany("Destaque")
                        .HasForeignKey("IdConquistas");

                    b.Navigation("Conquista");
                });

            modelBuilder.Entity("InfoGames.Models.DetalhesDoPreco", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("DetalhesDoPreco")
                        .HasForeignKey("InfoGames.Models.DetalhesDoPreco", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.DetalhesJogoModel", b =>
                {
                    b.HasOne("InfoGames.Models.JogoModel", "Jogo")
                        .WithOne("DetalhesJogo")
                        .HasForeignKey("InfoGames.Models.DetalhesJogoModel", "IdJogo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jogo");
                });

            modelBuilder.Entity("InfoGames.Models.Filme", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithMany("Filme")
                        .HasForeignKey("IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.Generos", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithMany("Genero")
                        .HasForeignKey("IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.GrupoDePacote", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithMany("GrupoDePacotes")
                        .HasForeignKey("IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.InformacaoDeSuporte", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("InformacaoDeSuporte")
                        .HasForeignKey("InfoGames.Models.InformacaoDeSuporte", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.JogoCompleto", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("JogoCompleto")
                        .HasForeignKey("InfoGames.Models.JogoCompleto", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.JogoModel", b =>
                {
                    b.HasOne("InfoGames.Models.LojaModel", "Loja")
                        .WithMany("Jogos")
                        .HasForeignKey("LojaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loja");
                });

            modelBuilder.Entity("InfoGames.Models.Metacritica", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("Metacritica")
                        .HasForeignKey("InfoGames.Models.Metacritica", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.Mp4", b =>
                {
                    b.HasOne("InfoGames.Models.Filme", "Filme")
                        .WithOne("Mp4")
                        .HasForeignKey("InfoGames.Models.Mp4", "IdFilme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("InfoGames.Models.NoticiaModel", b =>
                {
                    b.HasOne("InfoGames.Models.JogoModel", "Jogo")
                        .WithMany("Noticias")
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jogo");
                });

            modelBuilder.Entity("InfoGames.Models.Pacote", b =>
                {
                    b.HasOne("InfoGames.Models.GrupoDePacote", "GrupoDePacote")
                        .WithMany("Pacotes")
                        .HasForeignKey("GrupoDePacoteId");

                    b.Navigation("GrupoDePacote");
                });

            modelBuilder.Entity("InfoGames.Models.Plataforma", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("Plataforma")
                        .HasForeignKey("InfoGames.Models.Plataforma", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.RequisitoLinux", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("RequisitoLinux")
                        .HasForeignKey("InfoGames.Models.RequisitoLinux", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.RequisitoMac", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("RequisitoMac")
                        .HasForeignKey("InfoGames.Models.RequisitoMac", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.RequisitoPC", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithOne("RequisitoPC")
                        .HasForeignKey("InfoGames.Models.RequisitoPC", "IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.Screenshot", b =>
                {
                    b.HasOne("InfoGames.Models.DetalhesJogoModel", "DetalhesJogo")
                        .WithMany("Screenshot")
                        .HasForeignKey("IdDetalhesJogo");

                    b.Navigation("DetalhesJogo");
                });

            modelBuilder.Entity("InfoGames.Models.Webm", b =>
                {
                    b.HasOne("InfoGames.Models.Filme", "Filme")
                        .WithOne("Webm")
                        .HasForeignKey("InfoGames.Models.Webm", "IdFilme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("InfoGames.Models.Conquista", b =>
                {
                    b.Navigation("Destaque");
                });

            modelBuilder.Entity("InfoGames.Models.DetalhesJogoModel", b =>
                {
                    b.Navigation("Categoria");

                    b.Navigation("Classificacao");

                    b.Navigation("Conquista");

                    b.Navigation("DataDeLancamento");

                    b.Navigation("Demonstracao");

                    b.Navigation("DescritorDeConteudo");

                    b.Navigation("DetalhesDoPreco");

                    b.Navigation("Filme");

                    b.Navigation("Genero");

                    b.Navigation("GrupoDePacotes");

                    b.Navigation("InformacaoDeSuporte");

                    b.Navigation("JogoCompleto");

                    b.Navigation("Metacritica");

                    b.Navigation("Plataforma");

                    b.Navigation("RequisitoLinux");

                    b.Navigation("RequisitoMac");

                    b.Navigation("RequisitoPC");

                    b.Navigation("Screenshot");
                });

            modelBuilder.Entity("InfoGames.Models.Filme", b =>
                {
                    b.Navigation("Mp4");

                    b.Navigation("Webm");
                });

            modelBuilder.Entity("InfoGames.Models.GrupoDePacote", b =>
                {
                    b.Navigation("Pacotes");
                });

            modelBuilder.Entity("InfoGames.Models.JogoModel", b =>
                {
                    b.Navigation("DetalhesJogo");

                    b.Navigation("Noticias");
                });

            modelBuilder.Entity("InfoGames.Models.LojaModel", b =>
                {
                    b.Navigation("Jogos");
                });
#pragma warning restore 612, 618
        }
    }
}
