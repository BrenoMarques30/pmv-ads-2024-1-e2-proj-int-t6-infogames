using InfoGames.Data;
using InfoGames.Models;
using Microsoft.AspNetCore.Mvc;
using InfoGames.Middlewares;

namespace InfoGames.Controllers {
    public class JogoController : Controller {
        private readonly ApplicationDbContext _db;
        public JogoController(ApplicationDbContext db) {
            _db = db;
        }
        public ActionResult Index(int page = 1, int pageSize = 10) {
            // Perform pagination
            var jogosOnPage = _db.Jogos.Skip((page - 1) * pageSize).Take(pageSize).ToList();

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

        public async Task<IActionResult> GetApps() {
            GetApps getApps = new GetApps(_db);
            return await getApps.Index();
        }

        public async Task<IActionResult> GetAppDetails(string Id) {
            GetAppDetails getAppDetails = new GetAppDetails(_db);
            return await getAppDetails.Index(Id);
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
            JogoModel app = _db.Jogos.Find(id);
            if (app == null) {
                return NotFound();
            }
            // Get the details of the game from database. If not found, get from Steam API
            app.Detalhes = _db.DetalhesJogos.Find(app.DetalhesId);
            if (app.Detalhes == null) {
                GetAppDetails(app.Id);
            }
            return View(app);
        }
    }
}
