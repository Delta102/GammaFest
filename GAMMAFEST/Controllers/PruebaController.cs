using Microsoft.AspNetCore.Mvc;

namespace GAMMAFEST.Controllers
{
    public class PruebaController : Controller
    {
        public ActionResult Prueba() {
            return View();
        }
        [HttpPost]
        public ActionResult Prueba(int TempId)
        {
            ViewBag.tempId = TempId;
            return View();
        }
    }
}
