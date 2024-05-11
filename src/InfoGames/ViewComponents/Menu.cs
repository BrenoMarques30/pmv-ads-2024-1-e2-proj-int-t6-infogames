using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using InfoGames.Models;

namespace InfoGames.ViewComponents;

public class Menu : ViewComponent {
    public async Task<IViewComponentResult> InvokeAsync() {
        string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLoggado");

        if (string.IsNullOrEmpty(sessaoUsuario)) return View();

        Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

        return View(usuario);
    }
}
