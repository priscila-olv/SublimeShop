using SublimeShop.Models.DTOs;

namespace SublimeShop.Web.Services
{
    public interface ICarrinhoService
    {
        Task<List<CarrinhoProdutoDTO>> GetItens(string usuarioId);
        Task<CarrinhoProdutoDTO> AdicionaItens(CarrinhoProdutoAdicionaDto carrinhoProdutoAdicionaDto);
    }
}
