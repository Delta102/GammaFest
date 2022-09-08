using GAMMAFEST.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GAMMAFEST.Data;

namespace GAMMAFEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContextoDb _context;

        public HomeController(ILogger<HomeController> logger, ContextoDb context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index() { 
            return View();
        }
        [HttpGet]
        public IActionResult Index(int TempId)
        {
            ViewBag.tempId=TempId;
            IEnumerable<Evento> citaEvento = _context.Evento/*.Include(e=>e.Comentario)*/;
            return View(citaEvento);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}