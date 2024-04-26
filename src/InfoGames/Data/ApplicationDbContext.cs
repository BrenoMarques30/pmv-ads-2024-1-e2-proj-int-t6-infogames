﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using InfoGames.Models;

namespace InfoGames.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<Loja> Lojas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Loja>().HasData(
                               new Loja {
                                   Id = Guid.NewGuid().ToString(),
                                   Nome = "Steam",
                                   Url = "https://store.steampowered.com/",
                                   Logo = "https://upload.wikimedia.org/wikipedia/commons/8/83/Steam_icon_logo.svg",
                                   ChaveApi = "123456"
                               }
                             );
        }


        public DbSet<Jogo> Jogos { get; set; }


        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Classificacao> Classificacoes { get; set; }
        public DbSet<ClassificacaoIndicativa> ClassificacoesIndicativas { get; set; }
        public DbSet<Conquista> Conquistas { get; set; }
        public DbSet<DataDeLancamento> DatasDeLancamento { get; set; }
        public DbSet<Demos> Demos { get; set; }
        public DbSet<DescritorDeConteudo> DescritoresDeConteudo { get; set; }
        public DbSet<Destaque> Destaques { get; set; }
        public DbSet<DetalhesDoPreco> DetalhesDePrecos { get; set; }
        public DbSet<DetalhesJogo> DetalhesJogos { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<GrupoDePacote> GruposDePacotes { get; set; }
        public DbSet<InformacaoDeSuporte> InformacoesDeSuporte { get; set; }
        public DbSet<JogoCompleto> JogosCompletos { get; set; }
        public DbSet<Metacritica> Metacriticas { get; set; }
        public DbSet<Mp4> Mp4s { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<RequisitoLinux> RequisitosLinux { get; set; }
        public DbSet<RequisitoMac> RequisitosMac { get; set; }
        public DbSet<RequisitoPC> RequisitosPC { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }
        public DbSet<Webm> Webms { get; set; }
    }
}
