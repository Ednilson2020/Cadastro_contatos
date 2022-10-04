using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Cadastro_contatos.Models
{
    [Table("login")]
    public class login
    {
        [Display(Name = "Id")]
        [Column("idlogin")]
        [Key]
        public int idlogin { get; set; }
        public string nome  { get; set; }
        public string senha  { get; set; }
        public int nivel { get; set; }

    }
}
