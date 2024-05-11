using InfoGames.Data;
using InfoGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace InfoGames.Middlewares {
    public class GetAppPrices : Controller {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _db;

        public GetAppPrices(ApplicationDbContext db) {
            _httpClient = new HttpClient();
            _db = db;
        }

        // Retrieve all AppIds from Jogos table
        public async Task<IActionResult> Index() {
            var jogos = await _db.Jogos.ToListAsync();
            // join all AppIds into a single string separated by commas
            var appIds = string.Join(",", jogos.Select(j => j.AppId));


            return RedirectToAction("Index", "Jogo");
            //var response = await _httpClient.GetAsync($"https://store.steampowered.com/api/appdetails?appids={appIds}");
        }
    }
}