using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAMMAFEST.Models
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaInicioEvento { get; set; }
        public string ImagenTemp { get; set; }
        public string NombreEvento { get; set; }
        public string NombreImagen { get; set; }
        [NotMapped]
        public IFormFile ArchivoImagen { get; set; }
        public string Descripcion { get; set; }
        public string Protocolos { get; set; }
        public string IdPromotor { get; set; }
        [ForeignKey("IdPromotor")]
        public virtual Promotor? Promotor { get; set; }
    }
}