using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GAMMAFEST.Models
{
    public class Promotor:IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono  { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
    }
}
