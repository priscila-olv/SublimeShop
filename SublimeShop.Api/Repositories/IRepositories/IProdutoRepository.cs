using SublimeShop.Api.Entities;

namespace SublimeShop.Api.IRepositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutoPorCategoria(int id);
        Task<IEnumerable<Produto>> GetProdutos();

        Task<Produto> GetProduto(int id);
    }
}
