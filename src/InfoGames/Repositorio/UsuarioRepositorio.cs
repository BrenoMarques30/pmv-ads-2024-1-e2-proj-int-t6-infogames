using Microsoft.EntityFrameworkCore;
using InfoGames.Models;
using InfoGames.Data;

namespace InfoGames.Repositorio {
    public class UsuarioRepositorio : IUsuarioRepositorio {
        private readonly ApplicationDbContext _db;

        public UsuarioRepositorio(ApplicationDbContext db) {
            _db = db;
        }

        public Usuario BuscarPorLogin(string email) {
            return _db.Usuario.FirstOrDefault(m => m.Email == email);
        }
    }
}
