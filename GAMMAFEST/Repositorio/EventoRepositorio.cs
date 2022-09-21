using GAMMAFEST.Data;
using GAMMAFEST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GAMMAFEST.Repositorio
{
    public interface IEventoRepositorio
    {
        IEnumerable<Evento> ObtenerEventos(int? id);
        void CrearEvento(Evento evento);
    }
    public class EventoRepositorio: IEventoRepositorio
    {
        public readonly ContextoDb _context;
        public EventoRepositorio(ContextoDb context) {
            _context = context;
        }
        public IEnumerable<Evento> ObtenerEventos(int? id) {
            return _context.Evento.Include(p => p.Promotor).Where(e => e.EventoId == id); ;
        }

        public void CrearEvento(Evento evento) {
            _context.Add(evento);
            _context.SaveChangesAsync();
        }
    }
}
