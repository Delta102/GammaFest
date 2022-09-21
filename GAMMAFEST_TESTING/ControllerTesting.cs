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
    public class ControllerTesting
    {

        [Test]
        public void HomeTest01() {
            var controller = new HomeController(new ContextoDb());
            var view = controller.Index();
            Assert.IsNotNull(view);
        }

        private IWebHostEnvironment hostEnvironment;
        [Test]
        public void EventoTest01() {
            var controller = new EventoController(new FakeEventoRepositorio(), hostEnvironment);
            var view=controller.CrearEvento();
            Assert.IsNotNull(view);
        }

        [Test]
        public void EventoTest02()
        {
            var controller = new EventoController(new FakeEventoRepositorio(), hostEnvironment);
            var view = controller.IndexEvento(7);
            Assert.IsNotNull(view);
        }
    }
}
