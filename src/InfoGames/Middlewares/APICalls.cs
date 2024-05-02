using InfoGames.Models.Steam;
using InfoGames.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using InfoGames.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InfoGames.Middlewares {
    public class APICalls {

        public static List<SteamApp>? GetApps() {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestClient storeClient = new RestClient("https://api.steampowered.com/");
            RestRequest restReq = new RestRequest("ISteamApps/GetAppList/v2/");
            restReq.RequestFormat = DataFormat.Json;
            restReq.Method = Method.Get;

            var response = storeClient.Execute<dynamic>(restReq);
            JObject? jObject = JObject.Parse(response?.Content);
            var appList = jObject["applist"]?.Value<JObject>()?.ToObject<SteamAppList>()?.Apps;

            return appList;
        }

        public static AppData? GetAppDetails(string AppId) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestClient storeClient = new RestClient("https://store.steampowered.com/api/");

            RestRequest restReq = new RestRequest("appdetails/")
            .AddQueryParameter("l", "brazilian")
            .AddQueryParameter("cc", "BR")
            .AddQueryParameter("appids", AppId);
            restReq.RequestFormat = DataFormat.Json;
            restReq.Method = Method.Get;

            var response = storeClient.Execute<dynamic>(restReq);
            JObject? jObject = JObject.Parse(response?.Content);
            var appData = jObject[AppId]?.Value<JObject>()?.ToObject<RootDetails>(new Newtonsoft.Json.JsonSerializer { Converters = { new RequirementsConverter() } })?.Data;

            return appData;
        }
    }
}