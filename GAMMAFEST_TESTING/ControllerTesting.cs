using GAMMAFEST.Controllers;
using GAMMAFEST.Models;
using GAMMAFEST.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Moq;
using Microsoft.Extensions.Hosting.Internal;
using GAMMAFEST.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Scripting.Ast;

namespace GAMMAFEST_TESTING
{
    public class FakeEventoRepositorio : IEventoRepositorio
    {
        void IEventoRepositorio.CrearEvento(Evento evento)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Evento> IEventoRepositorio.ObtenerEventos(int? id)
        {
            return new List<Evento>();
        }
    }
    /*public class ControllerTesting
    {

        [Test]
        public void HomeTest01() {
            var controller = new HomeController(new ContextoDb());
            var view = controller.Index();
            Assert.IsNotNull(view);
        }
        [Test]
        public void EventoTest01() {
            var evento = new Evento();
            var moq = new Mock<IWebHostEnvironment>();
            moq.Setup(w => w.WebRootPath).Returns("E:\\CICLO VIII\\CALIDAD Y PRUEBAS DE SOFTWARE\\GAMMAFEST\\GAMMAFEST\\wwwroot\\");

        var controller = new EventoController(new FakeEventoRepositorio(), moq.Object);
        evento.EventoId=1;
        evento.FechaInicioEvento=Convert.ToDateTime("01/01/2001");
            evento.ImagenTemp="1";
            evento.NombreImagen = "1";
            evento.NombreEvento = "EventoTest1";
            evento.Descripcion = "Descripcion";
            evento.Protocolos = "Protocolos";
            evento.IdPromotor = "1";
            evento.AforoMaximo = 2;
            evento.IdUsuario = 1;
            evento.ArchivoImagen =;
            evento.ArchivoImagen =controller.SubirArchivo(evento.NombreImagen);
            



            var view=controller.CrearEvento(evento);
        }

        /*[Test]
        public void EventoTest02()
        {
            var controller = new EventoController(new FakeEventoRepositorio(), hostEnvironment);
            var view = controller.IndexEvento(7);
            Assert.IsNotNull(view);
        }
    }*/
}
