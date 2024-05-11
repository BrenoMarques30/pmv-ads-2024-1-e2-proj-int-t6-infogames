using InfoGames.Models;

namespace InfoGames.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin(string email);
    }
}
