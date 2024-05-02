using InfoGames.Data;
using InfoGames.Models;

namespace InfoGames.Middlewares {
    public class BuscarDetalhes {
        public static DetalhesJogoModel? PorIdJogo(string IdJogo, ApplicationDbContext _db) {
            return _db.DetalhesJogos.FirstOrDefault(j => j.IdJogo == IdJogo);
        }
        public static DetalhesJogoModel? PorId(string Id, ApplicationDbContext _db) {
            return _db.DetalhesJogos.FirstOrDefault(j => j.Id == Id);
        }
    }
}