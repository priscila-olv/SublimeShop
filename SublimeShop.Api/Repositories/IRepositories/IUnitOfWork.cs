using SublimeShop.Api.Repositories.IRepositories;

namespace SublimeShop.Api.IRepositories
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICarrinhoRepository CarrinhoRepository { get; }
        //ICategoriaRepository CategoriaRepository { get; }
        Task Commit();
    }
}
