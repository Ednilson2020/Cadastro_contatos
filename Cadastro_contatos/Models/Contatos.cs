using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_contatos.Models
{
    [Table("Contatos")]
    public class Contatos
    {
        [Display(Name = "Id")]
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres")]
        [Display(Name = "Informe o nome do contato")]
        [Column("Nome")]
        public string Nome { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Contato deve ser preenchido")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Digite um numro de contato de 9 digito")]
        [Display(Name = "Contato")]
        [Column("Contato")]
        public string Contato { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }
    }
}
