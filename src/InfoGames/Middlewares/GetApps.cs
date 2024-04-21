using InfoGames.Data;
using InfoGames.Models;
using Microsoft.AspNetCore.Mvc;
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


                for (int i = 0; i < appListResponse?.Applist.Apps.Count; i++) {
                    SteamApp? app = appListResponse.Applist.Apps[i];
                    _db.Jogos.Add(new JogoModel { Id = Guid.NewGuid().ToString(), AppId = app.Appid.ToString(), Nome = app.Name });
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