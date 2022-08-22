using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAMMAFEST.Models
{
    public class Blog
    {
        [Key]
        public int IdBlog { get; set; }
        public string DescripcionBlog { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PublicacionBlog { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }
        [ForeignKey("Id")]
        public virtual Promotor? Promotor { get; set; }
    }
}
