using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAMMAFEST.Models
{
    public class Entrada
    {
        [Key]
        public int EntradaId { get; set; }

        [ForeignKey("EventoId")]
        public virtual Evento? Evento { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }

    }
}