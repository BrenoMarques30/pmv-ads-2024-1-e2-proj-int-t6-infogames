using InfoGames.Data;
using InfoGames.Models;
using Microsoft.AspNetCore.Mvc;
using InfoGames.Middlewares;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace InfoGames.Controllers {
    public class JogoController : Controller {
        private readonly ApplicationDbContext _db;
        public JogoController(ApplicationDbContext db) {
            _db = db;
        }
        public ActionResult Index(int page = 1, int pageSize = 50) {
            // Perform pagination
            var jogosOnPage = _db.Jogos.OrderBy(j => j.Nome).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Pass data to the view
            ViewBag.Jogos = jogosOnPage;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = Math.Ceiling((double)_db.Jogos.Count() / pageSize);


            return View(jogosOnPage);
        }

        public IActionResult ChangePageSize(int pageSize) {
            return RedirectToAction("Index", new { pageSize });
        }

        public IActionResult RecuperarJogos() {
            var recuperarJogos = new RecuperarJogos();
            recuperarJogos.BuscarNaSteam(_db);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetAppPrices() { // Ainda não implementado 100%
            GetAppPrices getAppPrices = new GetAppPrices(_db);
            return await getAppPrices.Index();
        }

        public IActionResult Form(string method, string id) {
            if (method == "add") {
                return View();
            } else if (method == "edit" && !string.IsNullOrEmpty(id)) {
                var obj = _db.Jogos.Find(id);
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
                _db.Jogos.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Form");
        }

        public IActionResult Edit(JogoModel obj) {
            if (ModelState.IsValid) {
                _db.Jogos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(string id) {
            if (id == null || id == "") {
                return NotFound();
            }
            var obj = _db.Jogos.Find(id);
            if (obj == null) {
                return NotFound();
            }
            _db.Jogos.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(string id) {
            if (id == null || id == "") {
                return NotFound();
            }
            JogoModel? _jogo = ConstruirInstanciaJogo(id);
            if (_jogo == null) {
                return BadRequest();
            }
            ViewData["App"] = _jogo;

            if (_jogo.DetalhesJogo?.Dlc?.Count > 0) {
                List<JogoModel> dlcs = [];
                foreach (var dlc in _jogo.DetalhesJogo.Dlc) {
                    JogoModel? _dlc = BuscarJogo.PorAppId(dlc, _db);
                    if (_dlc is null) {
                        Debug.WriteLine("DLC " + dlc + " não encontrada no banco de dados.");
                        continue;
                    }
                    _dlc = ConstruirInstanciaJogo(_dlc.Id);
                    if (_dlc?.DetalhesJogo is not null) {
                        dlcs.Add(_dlc);
                    }
                }
                if (dlcs.Count > 0) ViewData["Dlcs"] = dlcs;
            }

            if (_jogo.DetalhesJogo?.JogoCompleto is not null) {
                JogoModel? _jogoCompleto = BuscarJogo.PorAppId(_jogo.DetalhesJogo.JogoCompleto.IdJogoCompleto, _db);
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
                    JogoModel? _demo = BuscarJogo.PorAppId(demo.Appid, _db);
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

            return View();
        }

        public JogoModel? ConstruirInstanciaJogo(string id) {
            JogoModel? _jogo = BuscarJogo.PorId(id, _db);
            if (_jogo == null) {
                return null;
            }

            _jogo.DetalhesJogo = BuscarDetalhes.PorIdJogo(_jogo.Id, _db);

            if (_jogo.DetalhesJogo is null) {
                Debug.WriteLine("Detalhes do _jogo não encontrados no banco de dados. Buscando da API Steam.");
                _ = RecuperarDetalhes.BuscarNaSteam(_jogo, _db);
                if (_jogo.DetalhesJogo is null) {
                    Debug.WriteLine("Detalhes do _jogo não encontrados na API Steam.");
                    return null;
                }
            } else {
                Debug.WriteLine("Detalhes do _jogo encontrados no banco de dados.");
                _ = RecuperarDetalhes.BuscarNoBancoDeDados(_jogo, _db);
                if (_jogo.DetalhesJogo is null) {
                    Debug.WriteLine("Erro ao processar banco de dados");
                    return null;
                }
            }
            return _jogo;
        }
    }
}
