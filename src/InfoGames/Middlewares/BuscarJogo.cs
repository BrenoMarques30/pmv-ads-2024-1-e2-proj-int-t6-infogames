using InfoGames.Data;
using InfoGames.Models;

namespace InfoGames.Middlewares {
    public class BuscarJogo {
        public static JogoModel? PorId(string id, ApplicationDbContext _db) {
            return _db.Jogos.FirstOrDefault(j => j.Id == id);
        }

        public static JogoModel? PorAppId(string appId, ApplicationDbContext _db) {
            return _db.Jogos.FirstOrDefault(j => j.AppId == appId);
        }
    }
}
