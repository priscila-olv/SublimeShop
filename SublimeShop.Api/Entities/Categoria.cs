using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SublimeShop.Api.Entities
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string NomeCategoria { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string IconCategoria { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
