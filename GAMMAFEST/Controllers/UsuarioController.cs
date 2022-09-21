using GAMMAFEST.Data;
using GAMMAFEST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GAMMAFEST.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContextoDb _context;

        public UsuarioController(ILogger<HomeController> logger, ContextoDb context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult CrearUsuario(int? id) {
            ViewBag.eventotemp = id;
            //int temp = _context.Usuario.Select(u=>u.EventoId);
            ViewBag.aforo2 = _context.Evento.Single(e => e.EventoId == id).AforoMaximo;
            
            if (_context.Usuario.Where(u=>u.EventoId == id).Count() < Convert.ToInt32(_context.Evento.Single(e => e.EventoId == id).AforoMaximo))
            {
                return View();
            }
            else
                return RedirectToAction("SoldOut", "Usuario");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearUsuario(Usuario usuario, int? id)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Usuario Creado Satisfactoriamente!!!";
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult IndexUsuario(int?id)
        {
            ViewBag.ni = _context.Evento.Single(e => e.EventoId == id).NombreImagen;
            ViewBag.ni2 = id;
            IEnumerable<Usuario> citaEvento = _context.Usuario.Where(u=>u.EventoId == id).Include(e=>e.Evento)/*.Include(e=>e.Comentario)*/;
            return View(citaEvento);
        }

        public IActionResult SoldOut() {
            return View();
        }
    }
}