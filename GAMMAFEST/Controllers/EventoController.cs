using GAMMAFEST.Data;
using GAMMAFEST.Models;
using GAMMAFEST.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GAMMAFEST.Controllers
{
    public class EventoController : Controller
    {
        public readonly IEventoRepositorio repositorio;
        public readonly IWebHostEnvironment _hostEnvironment;

        public EventoController(IEventoRepositorio repositorio, IWebHostEnvironment hostEnvironment)
        {
            this.repositorio = repositorio;
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
                repositorio.CrearEvento(evento);
                TempData["AlertMessage"] = "Evento Creado Satisfactoriamente!!!";
                return RedirectToAction("CrearEvento");
            }
            return View(evento);
        }

        [HttpGet]
        public IActionResult IndexEvento(int? id)
        {
            IEnumerable<Evento> listado = repositorio.ObtenerEventos(id);
            return View(listado);
        }
    }
}