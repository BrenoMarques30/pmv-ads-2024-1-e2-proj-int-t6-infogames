using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InfoGames.Models.Steam {
    public class GetAppsScheme {
        
    }
    public class SteamAppListResponse {
        public SteamAppList? Applist { get; set; }
    }

    public class SteamAppList {
        public List<SteamApp>? Apps { get; set; }
    }

    public class SteamApp {
        public string? Appid { get; set; }
        public string? Name { get; set; }
    }
}
