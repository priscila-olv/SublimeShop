namespace SublimeShop.Models.DTOs
{
    public class CarrinhoProdutoDTO
    {
        public int CarrinhoProdutoId { get; set; }
        public int ProdutoId { get; set; }
        public int CarrinhoId { get; set; }
        public int Quantidade { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string ImagemURLProduto { get; set; }
        public decimal PrecoProduto { get; set; }
        public decimal PrecoTotal { get; set; }
    }
}
