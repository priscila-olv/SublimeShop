using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SublimeShop.Api.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string NomeUsuario { get; set; }

        public Carrinho? Carrinho { get; set; }
    }
}
