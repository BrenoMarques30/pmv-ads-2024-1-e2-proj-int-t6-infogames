using InfoGames.Models.Steam;
using InfoGames.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using InfoGames.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace InfoGames.Middlewares {
    public class APICalls {

        public static List<SteamApp>? GetApps() {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestClient storeClient = new("https://api.steampowered.com/");
            RestRequest restReq = new("ISteamApps/GetAppList/v2/") {
                RequestFormat = DataFormat.Json,
                Method = Method.Get
            };

            var response = storeClient.Execute<dynamic>(restReq);
            if (response?.Content == null) {
                Debug.WriteLine("Erro ao tentar obter a lista de jogos");
                return null;
            }
            JObject? jObject = JObject.Parse(response.Content);
            var appList = jObject["applist"]?.Value<JObject>()?.ToObject<SteamAppList>()?.Apps;

            return appList;
        }

        public static AppData? GetAppDetails(string AppId) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestClient storeClient = new("https://store.steampowered.com/api/");

            RestRequest restReq = new RestRequest("appdetails/")
            .AddQueryParameter("l", "brazilian")
            .AddQueryParameter("cc", "BR")
            .AddQueryParameter("appids", AppId);
            restReq.RequestFormat = DataFormat.Json;
            restReq.Method = Method.Get;

            var response = storeClient.Execute<dynamic>(restReq);
            if (response?.Content == null) {
                Debug.WriteLine("Erro ao tentar obter a lista de jogos");
                return null;
            }
            try {
                JObject? jObject = JObject.Parse(response.Content);
                var appData = jObject[AppId]?.Value<JObject>()?.ToObject<RootDetails>(new Newtonsoft.Json.JsonSerializer { Converters = { new RequirementsConverter() } })?.Data;

                return appData;
            } catch (JsonReaderException) {
                Debug.WriteLine("Erro ao tentar converter JSON");
                return null;

            }
        }

        public static NewsData? GetAppNews(string AppId, string countOfEntries) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestClient storeClient = new("https://api.steampowered.com/");
            RestRequest restReq = new RestRequest("ISteamNews/GetNewsForApp/v0002/")
            .AddQueryParameter("appid", AppId)
            .AddQueryParameter("count", countOfEntries)
            .AddQueryParameter("maxlength", "3000")
            .AddQueryParameter("format", "json");
            restReq.RequestFormat = DataFormat.Json;
            restReq.Method = Method.Get;

            var response = storeClient.Execute<dynamic>(restReq);
            if (response?.Content == null) {
                Debug.WriteLine("Erro ao tentar obter a lista de jogos");
                return null;
            }
            try {
                JObject? jObject = JObject.Parse(response.Content);
                var appNews = jObject["appnews"]?.Value<JObject>()?.ToObject<NewsData>();

                return appNews;
            } catch (JsonReaderException) {
                Debug.WriteLine("Erro ao tentar converter JSON");
                return null;
            }
        }
    }
}