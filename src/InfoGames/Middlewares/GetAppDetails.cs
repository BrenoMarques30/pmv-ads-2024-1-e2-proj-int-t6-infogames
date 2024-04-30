using InfoGames.Data;
using InfoGames.Models;
using InfoGames.Models.Steam;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using RestSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Net.Http;
using Screenshot = InfoGames.Models.Screenshot;
using Webm = InfoGames.Models.Webm;
using Mp4 = InfoGames.Models.Mp4;

namespace InfoGames.Middlewares {
    public class GetAppDetails : Controller {
        private readonly ApplicationDbContext _db;
        private readonly HttpClient _httpClient;

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
                if (appDetails is null) {
                    return BadRequest("Failed to fetch app details.");
                } else {

                    var _DetalhesJogo = new DetalhesJogo {
                        Id = Guid.NewGuid().ToString(),
                        IdJogo = app.Id.ToString(),
                        Jogo = app,
                        Tipo = appDetails?.Type,
                        Nome = appDetails?.Name,
                        AppId = appDetails?.Appid,
                        RecomendacaoEtaria = appDetails?.RequiredAge,
                        EGratuito = appDetails?.IsFree,
                        SuporteAControle = appDetails?.ControllerSupport,
                        DescricaoDetalhada = appDetails?.DetailedDescription,
                        SobreOJogo = appDetails?.AboutTheGame,
                        DescricaoCurta = appDetails?.ShortDescription,
                        LinguasDisponiveis = appDetails?.SupportedLanguages,
                        ImagemPrincipal = appDetails?.HeaderImage,
                        Thumbnail = appDetails?.CapsuleImage,
                        Thumbnailv5 = appDetails?.CapsuleImagev5,
                        Website = appDetails?.Website,
                        NotificacaoLegal = appDetails?.LegalNotice,
                        NumeroDeLikes = appDetails?.Recommendations?.Total,
                        Dlc = appDetails?.Dlc,
                        Desenvolvedor = appDetails?.Developers,
                        Editor = appDetails?.Publishers,
                        Pacotes = appDetails?.Packages,

                    };

                    if (appDetails?.FullGame is not null) {
                        var _jogoCompleto = new JogoCompleto {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            IdJogoCompleto = appDetails?.FullGame?.Appid ?? "",
                            Nome = appDetails?.FullGame?.Name ?? "",
                        };
                        _DetalhesJogo.JogoCompleto = _jogoCompleto;
                        _ = _db.JogosCompletos.Add(_jogoCompleto);
                    }

                    if (appDetails?.PcRequirements is not null) {
                        var _requisito = new RequisitoPC {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Minimo = appDetails?.PcRequirements?.Requirements?.Minimum ?? "",
                            Recomendado = appDetails?.PcRequirements?.Requirements?.Recommended ?? "",
                        };
                        _DetalhesJogo.RequisitoPC = _requisito;
                        _ = _db.RequisitosPC.Add(_requisito);
                    }

                    if (appDetails?.MacRequirements is not null) {
                        var _requisito = new RequisitoMac {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Minimo = appDetails?.MacRequirements?.Requirements?.Minimum ?? "",
                            Recomendado = appDetails?.MacRequirements?.Requirements?.Recommended ?? "",
                        };
                        _DetalhesJogo.RequisitoMac = _requisito;
                        _ = _db.RequisitosMac.Add(_requisito);
                    }

                    if (appDetails?.LinuxRequirements is not null) {
                        var _requisito = new RequisitoLinux {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Minimo = appDetails?.LinuxRequirements?.Requirements?.Minimum ?? "",
                            Recomendado = appDetails?.LinuxRequirements?.Requirements?.Recommended ?? "",
                        };
                        _DetalhesJogo.RequisitoLinux = _requisito;
                        _ = _db.RequisitosLinux.Add(_requisito);
                    }

                    if (appDetails?.PackageGroups is not null) {
                        _DetalhesJogo.GrupoDePacotes = new List<GrupoDePacote>();
                        foreach (var packageGroup in appDetails.PackageGroups) {
                            var _grupoDePacote = new GrupoDePacote {
                                Id = Guid.NewGuid().ToString(),
                                IdDetalhesJogo = _DetalhesJogo.Id,
                                DetalhesJogo = _DetalhesJogo,
                                Nome = packageGroup?.Name,
                                Titulo = packageGroup?.Title,
                                Descricao = packageGroup?.Description,
                                SelecaoDeTexto = packageGroup?.SelectionText,
                                SalvarTexto = packageGroup?.SaveText,
                                ExibirTipo = packageGroup?.DisplayType,
                                EAssinaturaRecorrente = packageGroup?.IsRecurringSubscription,
                            };
                            if (packageGroup?.Subs is not null) {
                                _grupoDePacote.Pacotes = new List<Pacote>();
                                foreach (var sub in packageGroup.Subs) {
                                    var _sub = new Pacote {
                                        IdGrupoDePacote = _grupoDePacote.Id,
                                        GrupoDePacote = _grupoDePacote,
                                        PacoteId = sub?.Packageid,
                                        PorcentagemDoDescontoTexto = sub?.PercentSavingsText,
                                        PorcentagemDoDesconto = sub?.PercentSavings,
                                        OpcaoTexto = sub?.OptionText,
                                        OpcaoDescricao = sub?.OptionDescription,
                                        ObtidaGratuitamente = sub?.CanGetFreeLicense,
                                        LicencaEGratuita = sub?.IsFreeLicense,
                                        PrecoComDesconto = sub?.PriceInCentsWithDiscount,
                                    };
                                    _grupoDePacote.Pacotes.Add(_sub);
                                    _db.Pacotes.Add(_sub);
                                }
                            }
                            _DetalhesJogo.GrupoDePacotes.Add(_grupoDePacote);
                            _ = _db.GruposDePacotes.Add(_grupoDePacote);
                        }
                    }

                    if (appDetails?.Platforms is not null) {
                        var _platform = new Plataforma {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Windows = appDetails?.Platforms?.Windows,
                            Mac = appDetails?.Platforms?.Mac,
                            Linux = appDetails?.Platforms?.Linux,
                        };
                        _DetalhesJogo.Plataforma = _platform;
                        _ = _db.Plataformas.Add(_platform);
                    }

                    if (appDetails?.Metacritic is not null) {
                        var _metacritic = new Metacritica {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Pontuacao = appDetails.Metacritic.Score,
                            Url = appDetails.Metacritic.Url,
                        };
                        _DetalhesJogo.Metacritica = _metacritic;
                        _ = _db.Metacriticas.Add(_metacritic);
                    }

                    if (appDetails?.Categories is not null) {
                        _DetalhesJogo.Categoria = new List<Categoria>();
                        foreach (var category in appDetails.Categories) {
                            var _category = new Categoria {
                                Id = Guid.NewGuid().ToString(),
                                IdDetalhesJogo = _DetalhesJogo.Id,
                                DetalhesJogo = _DetalhesJogo,
                                IdCategoria = category.Id,
                                Descricao = category.Description,
                            };
                            _DetalhesJogo.Categoria.Add(_category);
                            _ = _db.Categorias.Add(_category);
                        }
                    }

                    if (appDetails?.Genres is not null) {
                        _DetalhesJogo.Genero = new List<Generos>();
                        foreach (var genre in appDetails.Genres) {
                            var _genre = new Generos {
                                Id = Guid.NewGuid().ToString(),
                                IdDetalhesJogo = _DetalhesJogo.Id,
                                DetalhesJogo = _DetalhesJogo,
                                IdGenero = genre.Id,
                                Descricao = genre.Description,
                            };
                            _DetalhesJogo.Genero.Add(_genre);
                            _ = _db.Generos.Add(_genre);
                        }
                    }

                    if (appDetails?.PriceOverview is not null) {
                        var _priceOverview = new DetalhesDoPreco {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Moeda = appDetails.PriceOverview.Currency,
                            PrecoInicial = appDetails.PriceOverview.Initial,
                            PrecoFinal = appDetails.PriceOverview.Final,
                            DescontoPorcentagem = appDetails.PriceOverview.DiscountPercent,
                            PrecoInicialFormatado = appDetails.PriceOverview.InitialFormatted,
                            PrecoFinalFormatado = appDetails.PriceOverview.FinalFormatted,
                        };
                        _DetalhesJogo.DetalhesDoPreco = _priceOverview;
                        _ = _db.DetalhesDePrecos.Add(_priceOverview);
                    }


                    if (appDetails?.Screenshots is not null) {
                        _DetalhesJogo.Screenshot = new List<Screenshot>();
                        foreach (var screenshot in appDetails.Screenshots) {
                            var _screenshot = new Screenshot {
                                Id = Guid.NewGuid().ToString(),
                                IdDetalhesJogo = _DetalhesJogo.Id,
                                DetalhesJogo = _DetalhesJogo,
                                UrlThumbnail = screenshot.PathThumbnail,
                                UrlImagemCompleta = screenshot.PathFull,
                            };
                            _DetalhesJogo.Screenshot.Add(_screenshot);
                            _ = _db.Screenshots.Add(_screenshot);
                        }
                    }

                    if (appDetails?.Movies is not null) {
                        _DetalhesJogo.Filme = new List<Filme>();
                        foreach (var movie in appDetails.Movies) {
                            var _movie = new Filme {
                                Id = Guid.NewGuid().ToString(),
                                IdDetalhesJogo = _DetalhesJogo.Id,
                                DetalhesJogo = _DetalhesJogo,
                                Nome = movie.Name,
                                Thumbnail = movie.Thumbnail,
                                Destacar = movie.Highlight,
                            };

                            if (movie.Webm is not null) {
                                var _webm = new Webm {
                                    Id = Guid.NewGuid().ToString(),
                                    IdFilme = _movie.Id,
                                    Filme = _movie,
                                    Max = movie.Webm.Max,
                                    _480 = movie.Webm._480
                                };
                                _movie.Webm = _webm;
                                //_ = _db.Webms.Add(_webm);
                            }

                            if (movie.Mp4 is not null) {
                                var _mp4 = new Mp4 {
                                    Id = Guid.NewGuid().ToString(),
                                    IdFilme = _movie.Id,
                                    Filme = _movie,
                                    Max = movie.Mp4.Max,
                                    _480 = movie.Mp4._480
                                };
                                _movie.Mp4 = _mp4;
                                //_ = _db.Mp4s.Add(_mp4);
                            }

                            _DetalhesJogo.Filme.Add(_movie);
                            _ = _db.Filmes.Add(_movie);
                        }
                    }

                    if (appDetails?.Achievements is not null) {
                        var _achievement = new Conquista {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Total = appDetails.Achievements.Total,
                        };

                        if (appDetails.Achievements.Highlighted is not null) {
                            _achievement.Destaque = new List<Destaque>();
                            foreach (var achievement in appDetails.Achievements.Highlighted) {
                                var _destaque = new Destaque {
                                    Id = Guid.NewGuid().ToString(),
                                    IdConquista = _achievement.Id,
                                    Conquista = _achievement,
                                    Nome = achievement.Name,
                                    UrlIcone = achievement.Path,
                                };
                                _achievement.Destaque.Add(_destaque);
                                _ = _db.Destaques.Add(_destaque);
                            }
                        }

                        _DetalhesJogo.Conquista = _achievement;
                        _ = _db.Conquistas.Add(_achievement);
                    }

                    if (appDetails?.ReleaseDate is not null) {
                        var _releaseDate = new DataDeLancamento {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Data = appDetails.ReleaseDate.Date,
                            EstaChegando = appDetails.ReleaseDate.ComingSoon,
                        };

                        _DetalhesJogo.DataDeLancamento = _releaseDate;
                        _ = _db.DatasDeLancamento.Add(_releaseDate);
                    }

                    if (appDetails?.SupportInfo is not null) {
                        var _supportInfo = new InformacaoDeSuporte {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Email = appDetails.SupportInfo.Email,
                            Url = appDetails.SupportInfo.Url,
                        };
                        _DetalhesJogo.InformacaoDeSuporte = _supportInfo;
                        _ = _db.InformacoesDeSuporte.Add(_supportInfo);
                    }

                    if (appDetails?.ContentDescriptors is not null) {
                        var _contentDescriptors = new DescritorDeConteudo {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Notas = appDetails.ContentDescriptors.Notes,
                        };
                        _DetalhesJogo.DescritorDeConteudo = _contentDescriptors;
                        _ = _db.DescritoresDeConteudo.Add(_contentDescriptors);
                    }

                    if (appDetails?.Ratings?.Dejus is not null) {
                        var _dejus = new ClassificacaoIndicativa {
                            Id = Guid.NewGuid().ToString(),
                            IdDetalhesJogo = _DetalhesJogo.Id,
                            DetalhesJogo = _DetalhesJogo,
                            Descricao = appDetails.Ratings.Dejus.Descriptors,
                            RecomendacaoEtaria = appDetails.Ratings.Dejus.RequiredAge,
                            BloquearPorIdade = appDetails.Ratings.Dejus.UseAgeGate,
                        };
                        _DetalhesJogo.Classificacao = _dejus;
                        _ = _db.ClassificacoesIndicativas.Add(_dejus);

                    }

                    app.DetalhesJogo = _DetalhesJogo;
                    _db.Jogos.Update(app);

                    try {
                        // Attempt to update the entity in the database
                        _db.Entry(app).State = EntityState.Modified;
                        _ = _db.SaveChanges();
                    } catch (DbUpdateConcurrencyException ex) {
                        // Handle the concurrency conflict
                        // Reload the entity from the database to get the latest version
                        await ex.Entries.Single().ReloadAsync();
                        await _db.SaveChangesAsync();
                        // Now you can try updating the entity again or handle the conflict as needed
                        Debug.WriteLine("Erro ao atualizar o jogo no banco de dados: " + ex.Message + ex.HelpLink);
                    }
                    return RedirectToAction("Detalhes", app);
                }
            }
        }
    }
}