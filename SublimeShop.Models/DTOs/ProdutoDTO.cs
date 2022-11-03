namespace SublimeShop.Models.DTOs
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string ImagemUrl { get; set; }
        public decimal PrecoProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }
}
