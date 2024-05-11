using InfoGames.Models;

namespace InfoGames.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(Usuario usuario);
        void RemoverSessaoUsuario();
        Usuario BuscarSessaoDoUsuario();


    }
}
