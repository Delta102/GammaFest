using GAMMAFEST.Data;
using GAMMAFEST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QRCoder;
using IronBarCode;

namespace GAMMAFEST.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContextoDb _context;
        public readonly IWebHostEnvironment _hostEnvironment;

        public UsuarioController(ILogger<HomeController> logger, ContextoDb context, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _context = context;
            _hostEnvironment = hostEnvironment;
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
                return RedirectToAction(nameof(Qr));
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
        public IActionResult Qr()
        {
            if (_context.Usuario.Count() > 0)
            {
                var idvar = _context.Usuario.OrderBy(u => u.IdUsuario).Last().IdUsuario;
                var nombre = _context.Usuario.Single(u => u.IdUsuario == idvar).Nombre;
                var apellido = _context.Usuario.Single(u => u.IdUsuario == idvar).Apellido;
                ViewBag.idtempvar = idvar;
                ViewBag.text = "Nombres: " + nombre + "\nApellidos: " + apellido;
                ViewBag.idUser = idvar;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Qr(GenerateQRCodeModel qrGen)
        {
            try {
                GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(qrGen.QRCodeText, 200);
                barcode.AddBarcodeValueTextBelowBarcode();
                // Styling a QR code and adding annotation text
                barcode.SetMargins(10);
                barcode.ChangeBarCodeColor(Color.BlueViolet);
                string path = Path.Combine(_hostEnvironment.WebRootPath, "GeneratedQRCode");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filePath = Path.Combine(_hostEnvironment.WebRootPath, "GeneratedQRCode/qrcode"+ qrGen.IdUsuario+1+ ".png");
                barcode.SaveAsPng(filePath);
                string fileName = Path.GetFileName(filePath);
                string imageUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
                ViewBag.QrCodeUri = imageUrl;
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }
    }
}