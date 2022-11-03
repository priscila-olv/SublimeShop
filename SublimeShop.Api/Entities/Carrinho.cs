namespace SublimeShop.Api.Entities
{
    public class Carrinho
    {
        public int CarrinhoId { get; set; }
        public string UsuarioId { get; set; }

        public ICollection<CarrinhoProduto> CarrinhoProdutos { get; set; }
    }
}
