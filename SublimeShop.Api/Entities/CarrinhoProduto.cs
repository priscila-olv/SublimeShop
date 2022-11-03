using System.ComponentModel.DataAnnotations;

namespace SublimeShop.Api.Entities
{
    public class CarrinhoProduto
    {
        [Key]
        public int CarrinhoProdutoId { get; set; }
        public int ProdutoId { get; set; }
        public int CarrinhoId { get; set; }
        public int Quantidade { get; set; }

        public Carrinho? Carrinho { get; set; }
        public Produto? Produto { get; set; }
    }
}
