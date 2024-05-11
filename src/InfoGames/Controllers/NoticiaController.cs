using InfoGames.Data;
using InfoGames.Models;
using Microsoft.AspNetCore.Mvc;
using InfoGames.Middlewares;
using System.Diagnostics;

namespace InfoGames.Controllers {
    public class NoticiaController(ApplicationDbContext db) : Controller {
        public IActionResult Index() {
            var noticias = db.Noticias.OrderByDescending(n => n.Data).ToList();

            foreach (var noticia in noticias) {
                if (noticia.Data == null) continue;
                long unixTime = long.Parse(noticia.Data);
                DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
                noticia.Data = dateTime.ToString("dd/MM/yyyy");
            }
            ViewData["Noticias"] = noticias;

            return View();
        }

        public IActionResult RecuperarNoticias(string AppId, string NumeroDeNoticias) {
            var recuperarNoticias = new RecuperarNoticias();
            recuperarNoticias.BuscarNaSteam(db, AppId, NumeroDeNoticias);
            return RedirectToAction("Index");
        }

    }
}
