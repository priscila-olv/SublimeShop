using Microsoft.Build.Framework;

namespace SublimeShop.Models.DTOs
{
    public class CarrinhoProdutoAdicionaDto
    {
        [Required]
        public int CarrinhoId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

    }
}
