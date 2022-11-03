using SublimeShop.Api.Entities;
using SublimeShop.Api.IRepositories;
using SublimeShop.Models.DTOs;

namespace SublimeShop.Api.Repositories.IRepositories
{
    public interface ICarrinhoRepository : IRepository<CarrinhoProduto>
    {

        Task<IEnumerable<CarrinhoProduto>> GetProdutos(string usuarioId);

        Task<CarrinhoProduto> GetProduto(int id);

        Task<CarrinhoProduto> AddProduto(CarrinhoProdutoAdicionaDto carrinhoProdutoAdicionaDto);

    }
}
