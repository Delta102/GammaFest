using GAMMAFEST.Data;
using GAMMAFEST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GAMMAFEST.Controllers
{
    public class EventoController : Controller
    {
        public readonly ContextoDb _context;
        public readonly IWebHostEnvironment _hostEnvironment;

        public EventoController(ContextoDb context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult CrearEvento() {
            //ViewData["Id"] = new SelectList(_context.Promotor, "Id", "Id");
            return View();
        }
        private string SubirArchivo(Evento evento)
        {
            string? nArchivo = null;
            string? temp1 = null;
            if (evento.ArchivoImagen != null)
            {
                string path = _hostEnvironment.WebRootPath;
                nArchivo = Path.GetFileNameWithoutExtension(evento.ArchivoImagen.FileName);
                string x = Path.GetExtension(evento.ArchivoImagen.FileName);
                evento.NombreImagen = nArchivo + x;
                temp1 = nArchivo + x;
                string z = Path.Combine(path + "/image/", nArchivo + x);
                using (var fileStream = new FileStream(z, FileMode.Create))
                {
                    evento.ArchivoImagen.CopyTo(fileStream);
                }
            }
            return temp1;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearEvento(Evento evento) {
            if (ModelState.IsValid) {
                evento.NombreImagen = SubirArchivo(evento);
                _context.Add(evento);
                _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Evento Creado Satisfactoriamente!!!";
                return RedirectToAction("CrearEvento");
            }
            return View(evento);
        }

        [HttpGet]
        public IActionResult IndexEvento(int? id)
        {
            IEnumerable<Evento> listado = _context.Evento.Include(p=>p.Promotor).Where(e=>e.EventoId == id);
            return View(listado);
        }
    }
}