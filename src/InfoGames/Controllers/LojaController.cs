using Microsoft.AspNetCore.Mvc;

namespace InfoGames.Controllers {
    public class LojaController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
