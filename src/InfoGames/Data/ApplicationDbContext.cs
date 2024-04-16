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
                                   Id = "1",
                                   Nome = "Steam",
                                   Url = "https://store.steampowered.com/",
                                   Logo = "https://upload.wikimedia.org/wikipedia/commons/8/83/Steam_icon_logo.svg",
                                   ChaveApi = "123456"
                               }
                             );
        }
    }
}
