using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SublimeShop.Api.Entities
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string? NomeProduto { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string? DescricaoProduto { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "varchar")]
        public string? ImagemUrl { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecoProduto { get; set; }

        public int QuantidadeProduto { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public ICollection<CarrinhoProduto> CarrinhoProdutos { get; set; }
    }
}
