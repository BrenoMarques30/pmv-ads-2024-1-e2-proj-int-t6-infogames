using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using InfoGames.Models;

namespace InfoGames.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<LojaModel> Lojas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<LojaModel>().HasData(
                               new LojaModel {
                                   Id = Guid.NewGuid().ToString(),
                                   Nome = "Steam",
                                   Url = "https://store.steampowered.com/",
                                   Logo = "https://upload.wikimedia.org/wikipedia/commons/8/83/Steam_icon_logo.svg",
                                   ChaveApi = "123456"
                               }
                             );
        }

        public DbSet<JogoModel> Jogos { get; set; }
        public DbSet<DetalhesJogo> DetalhesJogos { get; set; }
        //public DbSet<Fullgame> Fullgames { get; set; }
        //public DbSet<PcRequirements> PcRequirements { get; set; }
        //public DbSet<MacRequirements> MacRequirements { get; set; }
        //public DbSet<LinuxRequirements> LinuxRequirements { get; set; }
        //public DbSet<PriceOverview> PriceOverviews { get; set; }
        //public DbSet<PackageGroup> PackageGroups { get; set; }
        //public DbSet<Package> Packages { get; set; }
        //public DbSet<Platforms> Platforms { get; set; }
        //public DbSet<Genre> Genres { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Screenshot> Screenshots { get; set; }
        //public DbSet<ReleaseDate> ReleaseDates { get; set; }
        //public DbSet<Movie> Movies { get; set; }
        //public DbSet<Webm> webms { get; set; }
        //public DbSet<Mp4> mp4s { get; set; }
        //public DbSet<ReleaseDate> releaseDates { get; set; }
        //public DbSet<SupportInfo> SupportInfos { get; set; }
        //public DbSet<ContentDescriptors> ContentDescriptors { get; set; }
        //public DbSet<Ratings> Ratings { get; set; }
        //public DbSet<Dejus> Dejus { get; set; }

    }
}
