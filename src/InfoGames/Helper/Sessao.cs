using InfoGames.Models;
//using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace InfoGames.Helper;

public class Sessao : ISessao
{
    private readonly IHttpContextAccessor _httpContext;

    public Sessao(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public Usuario BuscarSessaoDoUsuario()
    {
        string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLoggado");
        if (string.IsNullOrEmpty(sessaoUsuario)) return null;
        return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
    }

    public void CriarSessaoUsuario(Usuario usuario)
    {
        string var = JsonConvert.SerializeObject(usuario);
        _httpContext.HttpContext.Session.SetString("sessaoUsuarioLoggado", var);
    }

    public void RemoverSessaoUsuario()
    {
        _httpContext.HttpContext.Session.Remove("sessaoUsuarioLoggado");
    }
}
