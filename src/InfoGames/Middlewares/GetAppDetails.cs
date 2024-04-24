using InfoGames.Data;
using InfoGames.Models;
using InfoGames.Models.Steam;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using RestSharp;
using Microsoft.EntityFrameworkCore;

namespace InfoGames.Middlewares {
    public class GetAppDetails : Controller {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _db;

        public GetAppDetails(ApplicationDbContext db) {
            _httpClient = new HttpClient();
            _db = db;
        }

        public async Task<IActionResult> Index(string Id) {
            if (Id == null) {
                return BadRequest("Invalid app id.");
            }
            if (_db.Jogos.Find(Id) == null) {
                return BadRequest("App not found.");
            } else {
                Jogo? app = _db.Jogos.Find(keyValues: Id);
                if (app == null) {
                    return BadRequest("App not found.");
                }
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                RestClient storeClient = new RestClient("https://store.steampowered.com/api/");

                RestRequest restReq = new RestRequest("appdetails/")
                .AddQueryParameter("l", "brazilian")
                .AddQueryParameter("cc", "BR")
                .AddQueryParameter("appids", app?.AppId);
                restReq.RequestFormat = DataFormat.Json;
                restReq.Method = Method.Get;

                var response = storeClient.Execute<dynamic>(restReq);
                JObject jObject = JObject.Parse(response?.Content);
                var appDetails = jObject[app?.AppId]?.Value<JObject>()?.ToObject<RootDetails>(new Newtonsoft.Json.JsonSerializer { Converters = { new RequirementsConverter() } })?.Data;
                if (appDetails is not null) {

                    var _DetalhesJogo = new DetalhesJogo {
                        Id = Guid.NewGuid().ToString(),
                        IdJogo = app.Id.ToString(),
                        Jogo = app,
                        Type = appDetails?.Type,
                        Name = appDetails?.Name,
                        AppId = appDetails?.Appid,
                        RequiredAge = appDetails?.RequiredAge,
                        IsFree = appDetails?.IsFree,
                        ControllerSupport = appDetails?.ControllerSupport,
                        DetailedDescription = appDetails?.DetailedDescription,
                        AboutTheGame = appDetails?.AboutTheGame,
                        ShortDescription = appDetails?.ShortDescription,
                        SupportedLanguages = appDetails?.SupportedLanguages,
                        HeaderImage = appDetails?.HeaderImage,
                        CapsuleImage = appDetails?.CapsuleImage,
                        CapsuleImagev5 = appDetails?.CapsuleImagev5,
                        Website = appDetails?.Website,
                        LegalNotice = appDetails?.LegalNotice,
                        RecommendationsTotal = appDetails?.Recommendations?.Total,
                        Dlc = appDetails?.Dlc,
                        Developers = appDetails?.Developers,
                        Publishers = appDetails?.Publishers,
                        Packages = appDetails?.Packages,
                        //PackageGroups = (ICollection<GrupoDePacote>?)(appDetails?.PackageGroups),
                        //Platforms = (ICollection<Plataformas>?)(appDetails?.Platforms),
                        //Metacritic = (ICollection<Metacritica>?)(appDetails?.Metacritic),
                        //Categories = (ICollection<Categoria>?)(appDetails?.Categories),
                        //Genres = (ICollection<Genero>?)(appDetails?.Genres),
                        //Screenshots = (ICollection<Models.Screenshot>?)(appDetails?.Screenshots),
                        //Movies = (ICollection<Filme>?)(appDetails?.Movies),
                        //Achievements = (ICollection<Conquista>?)(appDetails?.Achievements),
                        //ReleaseDate = (ICollection<DataDeLancamento>?)(appDetails?.ReleaseDate),
                        //SupportInfo = (ICollection<InformacaoDeSuporte>?)(appDetails?.SupportInfo),
                        //ContentDescriptors = (ICollection<DescritorDeConteudo>?)(appDetails?.ContentDescriptors),
                        //Ratings = (ICollection<Classificacao>?)(appDetails?.Ratings),

                    };

                    if (appDetails?.FullGame is not null) {
                        var _jogoCompleto = new JogoCompleto {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            FullGameAppId = appDetails?.FullGame?.Appid ?? "",
                            Name = appDetails?.FullGame?.Name ?? "",
                        };
                        _DetalhesJogo.JogoCompleto = _jogoCompleto;
                    }

                    if (appDetails?.PcRequirements is not null) {
                        var _requisito = new RequisitoPC {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Minimum = appDetails?.PcRequirements?.Requirements?.Minimum ?? "",
                            Recommended = appDetails?.PcRequirements?.Requirements?.Recommended ?? "",
                        };
                        _DetalhesJogo.RequisitoPC = _requisito;
                    }

                    if (appDetails?.MacRequirements is not null) {
                        var _requisito = new RequisitoMac {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Minimum = appDetails?.MacRequirements?.Requirements?.Minimum ?? "",
                            Recommended = appDetails?.MacRequirements?.Requirements?.Recommended ?? "",
                        };
                        _DetalhesJogo.RequisitoMac = _requisito;
                    }

                    if (appDetails?.LinuxRequirements is not null) {
                        var _requisito = new RequisitoLinux {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Minimum = appDetails?.LinuxRequirements?.Requirements?.Minimum ?? "",
                            Recommended = appDetails?.LinuxRequirements?.Requirements?.Recommended ?? "",
                        };
                        _DetalhesJogo.RequisitoLinux = _requisito;
                    }

                    //if (appDetails?.PackageGroups is not null) {
                    //    _DetalhesJogo.PackageGroups = new List<GrupoDePacote>();
                    //    foreach (var packageGroup in appDetails.PackageGroups) {
                    //        var _grupoDePacote = new GrupoDePacote {
                    //            Id = Guid.NewGuid().ToString(),
                    //            IdDetalhesJogo = _DetalhesJogo.Id,
                    //            DetalhesJogo = _DetalhesJogo,
                    //            Name = packageGroup?.Name,
                    //            Title = packageGroup?.Title,
                    //            Description = packageGroup?.Description,
                    //            SelectionText = packageGroup?.SelectionText,
                    //            SaveText = packageGroup?.SaveText,
                    //            DisplayType = packageGroup?.DisplayType,
                    //            IsRecurringSubscription = packageGroup?.IsRecurringSubscription,
                    //        };
                    //        if (packageGroup?.Subs is not null) {
                    //            _grupoDePacote.Packages = new List<Pacote>();
                    //            foreach (var sub in packageGroup.Subs) {
                    //                var _sub = new Pacote {
                    //                    IdGrupoDePacote = _grupoDePacote.Id,
                    //                    GrupoDePacote = _grupoDePacote,
                    //                    PackageId = sub?.Packageid,
                    //                    PercentSavingsText = sub?.PercentSavingsText,
                    //                    PercentSavings = sub?.PercentSavings,
                    //                    OptionText = sub?.OptionText,
                    //                    OptionDescription = sub?.OptionDescription,
                    //                    CanGetFreeLicense = sub?.CanGetFreeLicense,
                    //                    IsFreeLicense = sub?.IsFreeLicense,
                    //                    PriceInCentsWithDiscount = sub?.PriceInCentsWithDiscount,
                    //                };
                    //                _grupoDePacote.Packages.Add(_sub);
                    //            }
                    //        }
                    //        _DetalhesJogo.PackageGroups.Add(_grupoDePacote);
                    //    }
                    //}

                    app.DetalhesJogo = _DetalhesJogo;
                    _ = _db.DetalhesJogos.Add(_DetalhesJogo);

                    //try {
                    //    // Attempt to update the entity in the database
                    //    _db.Entry(app).State = EntityState.Modified;
                    //    _ = await _db.SaveChangesAsync();
                    //} catch (DbUpdateConcurrencyException ex) {
                    //    // Handle the concurrency conflict
                    //    // Reload the entity from the database to get the latest version
                    //    await ex.Entries.Single().ReloadAsync();
                    //    // Now you can try updating the entity again or handle the conflict as needed
                    //}
                    _db.Jogos.Update(app);
                    _ = await _db.SaveChangesAsync();
                    return RedirectToAction("Detalhes", app);
                }

                return BadRequest("Failed to fetch app details.");

            }
        }
    }
}