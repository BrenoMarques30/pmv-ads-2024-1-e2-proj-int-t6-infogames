using InfoGames.Data;
using InfoGames.Models;
using Microsoft.AspNetCore.Mvc;


namespace InfoGames.Controllers {
    public class LojaController : Controller {
        private readonly ApplicationDbContext _db;
        public LojaController(ApplicationDbContext db) {
            _db = db;
        }
        public IActionResult Index() {
            List<LojaModel> objLojasList = _db.Lojas.ToList();
            return View(objLojasList);
        }

        public IActionResult Form(string method, string id) {
            if (method == "add") {
                return View();
            } else if (method == "edit" && !string.IsNullOrEmpty(id)) {
                var obj = _db.Lojas.Find(id);
                if (obj == null) {
                    return NotFound();
                }
                return View(obj);
            } else {
                return BadRequest();
            }
        }

        public IActionResult Add(LojaModel obj) {
            obj.Id = Guid.NewGuid().ToString();
            if (ModelState.IsValid) {
                _db.Lojas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Form");
        }


        public IActionResult Edit(LojaModel obj) {
            if (ModelState.IsValid) {
                _db.Lojas.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(string id) {
            if (id == null || id == "") {
                return NotFound();
            }
            var obj = _db.Lojas.Find(id);
            if (obj == null) {
                return NotFound();
            }
            _db.Lojas.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
