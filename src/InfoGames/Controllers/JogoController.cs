using InfoGames.Data;
using InfoGames.Models;
using Microsoft.AspNetCore.Mvc;
using InfoGames.Middlewares;
using System.Diagnostics;

namespace InfoGames.Controllers {
    public class JogoController(ApplicationDbContext db) : Controller {
        public ActionResult Index(int page = 1, int pageSize = 50, string searchTerm = "") {
            var jogosFiltrados = db.Jogos.Where(j => j.Nome.Contains(searchTerm)).OrderBy(j => j.Nome).ToList();

            var jogosOnPage = jogosFiltrados.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            int totalPages = (int)Math.Ceiling((double)jogosFiltrados.Count / pageSize);

            var paginationHelper = new Paginacao(CreateNewBasket);

            // Pass data to the view
            ViewBag.DboJogosVazio = !db.Jogos.Any();
            ViewBag.Jogos = jogosOnPage;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;
            ViewBag.TotalPages = totalPages;
            ViewBag.Pagination = paginationHelper.GeneratePagination(page, pageSize, searchTerm, totalPages);

            return View();
        }

        private string CreateNewBasket(int page, int pageSize, string searchTerm) {
            return $"/Jogo/Index?page={page}&pageSize={pageSize}&searchTerm={searchTerm}";
        }

        public IActionResult ChangePageSize(int pageSize, string searchTerm) {
            return RedirectToAction("Index", new { pageSize, searchTerm });
        }

        public IActionResult Search(string searchTerm) {
            return RedirectToAction("Index", new { searchTerm });
        }

        public IActionResult RecuperarJogos() {
            var recuperarJogos = new RecuperarJogos();
            recuperarJogos.BuscarNaSteam(db);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetAppPrices() { // Ainda não implementado 100%
            GetAppPrices getAppPrices = new(db);
            return await getAppPrices.Index();
        }

        public IActionResult Form(string method, string id) {
            if (method == "add") {
                return View();
            } else if (method == "edit" && !string.IsNullOrEmpty(id)) {
                var obj = db.Jogos.Find(id);
                if (obj == null) {
                    return NotFound();
                }
                return View(obj);
            } else {
                return BadRequest();
            }
        }

        public IActionResult Add(JogoModel obj) {
            if (ModelState.IsValid) {
                db.Jogos.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Form");
        }

        public IActionResult Edit(JogoModel obj) {
            if (ModelState.IsValid) {
                db.Jogos.Update(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(string id) {
            if (id == null || id == "") {
                return NotFound();
            }
            var obj = db.Jogos.Find(id);
            if (obj == null) {
                return NotFound();
            }
            db.Jogos.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult JogoNaoEncontrado() {
            return View();
        }

        public IActionResult Detalhes(string id) {
            if (id == null || id == "") {
                return RedirectToAction("JogoNaoEncontrado");
            }
            JogoModel? _jogo = ConstruirInstanciaJogo(id);
            if (_jogo == null) {
                return RedirectToAction("JogoNaoEncontrado");
            }
            ViewData["App"] = _jogo;

            if (_jogo.DetalhesJogo?.Dlc?.Count > 0) {
                List<JogoModel> dlcs = [];
                foreach (var dlc in _jogo.DetalhesJogo.Dlc) {
                    JogoModel? _dlc = BuscarJogo.PorAppId(dlc, db);
                    if (_dlc is null) {
                        Debug.WriteLine("DLC " + dlc + " não encontrada no banco de dados.");
                        continue;
                    }
                    dlcs.Add(_dlc);
                }
                if (dlcs.Count > 0) ViewData["Dlcs"] = dlcs;
            }

            if (_jogo.DetalhesJogo?.JogoCompleto is not null) {
                JogoModel? _jogoCompleto = BuscarJogo.PorAppId(_jogo.DetalhesJogo.JogoCompleto.IdJogoCompleto, db);
                if (_jogoCompleto is null) {
                    Debug.WriteLine("Jogo completo " + _jogo.DetalhesJogo.JogoCompleto.IdJogoCompleto + " não encontrado no banco de dados.");
                } else {
                    _jogoCompleto = ConstruirInstanciaJogo(_jogoCompleto.Id);
                    if (_jogoCompleto is not null) {
                        ViewData["JogoCompleto"] = _jogoCompleto;
                    }
                }
            }

            if (_jogo.DetalhesJogo?.Demonstracao is not null) {
                List<JogoModel> demos = [];
                foreach (var demo in _jogo.DetalhesJogo.Demonstracao) {
                    if (demo.Appid is null) {
                        Debug.WriteLine("Appid da demo não encontrado.");
                        continue;
                    }
                    JogoModel? _demo = BuscarJogo.PorAppId(demo.Appid, db);
                    if (_demo is null) {
                        Debug.WriteLine("Demo " + demo.Appid + " não encontrada no banco de dados.");
                        continue;
                    }
                    _demo = ConstruirInstanciaJogo(_demo.Id);
                    if (_demo?.DetalhesJogo is not null) {
                        demos.Add(_demo);
                    }
                }
                if (demos.Count > 0) ViewData["Demos"] = demos;
            }
            var noticias = BuscarNoticiaNoDB(_jogo.AppId);
            if (noticias is null) {
                Debug.WriteLine("Notícias do app \"" + _jogo.Nome + "\" não encontradas no banco de dados. Buscando da API Steam.");
                _ = BuscarNoticiasNaSteam(_jogo.AppId);
                ViewData["Noticias"] = BuscarNoticiaNoDB(_jogo.AppId);
            } else {
                Debug.WriteLine("Notícias do app \"" + _jogo.Nome + "\" encontradas no banco de dados.");
                ViewData["Noticias"] = noticias;
            }


            return View();
        }

        public List<NoticiaModel> BuscarNoticiaNoDB(string AppId) {
            var noticias = db.Noticias.Where(n => n.AppId == AppId).OrderByDescending(n => n.Data).ToList();
            if (noticias is null || noticias.Count == 0) {
                return null;
            }
            foreach (var noticia in noticias) {
                if (noticia.Data == null) continue;
                long unixTime = long.Parse(noticia.Data);
                DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
                noticia.Data = dateTime.ToString("dd/MM/yyyy");
            }

            return noticias;
        }

        public string BuscarNoticiasNaSteam(string AppId) {
            var recuperarNoticias = new RecuperarNoticias();
            recuperarNoticias.BuscarNaSteamXML(db, AppId);
            return "Notícias recuperadas com sucesso.";
        }

        public JogoModel? ConstruirInstanciaJogo(string id) {
            JogoModel? _jogo = BuscarJogo.PorId(id, db);
            if (_jogo == null) {
                return null;
            }
            Debug.WriteLine("Buscando app \"" + _jogo.Nome + "\" no banco de dados.");
            _jogo.DetalhesJogo = BuscarDetalhes.PorIdJogo(_jogo.Id, db);

            if (_jogo.DetalhesJogo is null) {
                Debug.WriteLine("Detalhes do app \"" + _jogo.Nome + "\" não encontrados no banco de dados. Buscando da API Steam.");
                _ = RecuperarDetalhes.BuscarNaSteam(_jogo, db);
                if (_jogo.DetalhesJogo is null) {
                    Debug.WriteLine("Detalhes do app \"" + _jogo.Nome + "\" não encontrados na API Steam.");
                    return null;
                }
            } else {
                Debug.WriteLine("Detalhes do app \"" + _jogo.Nome + "\" encontrados no banco de dados.");
                _ = RecuperarDetalhes.BuscarNoBancoDeDados(_jogo, db);
                if (_jogo.DetalhesJogo is null) {
                    Debug.WriteLine("Erro ao processar banco de dados");
                    return null;
                }
            }

            return _jogo;
        }
    }
}
