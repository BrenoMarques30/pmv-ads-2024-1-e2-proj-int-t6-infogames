using InfoGames.Data;
using InfoGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace InfoGames.Middlewares {
    public class GetApps : Controller {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _db;

        public GetApps(ApplicationDbContext db) {
            _httpClient = new HttpClient();
            _db = db;
        }
        public async Task<IActionResult> Index() {
            var response = await _httpClient.GetAsync("https://api.steampowered.com/ISteamApps/GetAppList/v2");
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var appListResponse = JsonConvert.DeserializeObject<SteamAppListResponse>(content);
                // Remove leading blank space from app names, if any
                foreach (var app in appListResponse.Applist.Apps) {
                    if (app.Name.Length > 0 && app.Name[0] == ' ') app.Name = new string(app.Name.SkipWhile(c => c == ' ').ToArray());
                }
                // Order the app list by name
                var orderedApps = appListResponse.Applist.Apps.OrderBy(app => app.Name);

                var loja = _db.Lojas.FirstOrDefault(l => l.Nome == "Steam");
                if (loja == null) return BadRequest("Loja não encontrada.");
                foreach (var app in orderedApps) {
                    if (app.Name == "" || app.Name == null) continue;
                    _db.Jogos.Add(new Jogo { Id = Guid.NewGuid().ToString(), AppId = app.Appid.ToString(), Nome = app.Name, Loja=loja, LojaId=loja.Id });
                }
                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "Jogo");
            } else {
                // Handle error
                return View("Error");
            }
        }
    }
}

public class SteamAppListResponse {
    public SteamAppList Applist { get; set; }
}

public class SteamAppList {
    public List<SteamApp> Apps { get; set; }
}

public class SteamApp {
    public int Appid { get; set; }
    public string Name { get; set; }
}