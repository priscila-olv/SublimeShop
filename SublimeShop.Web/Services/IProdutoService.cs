using SublimeShop.Models.DTOs;

namespace SublimeShop.Web.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetAll();
        Task<ProdutoDTO> GetById(int id);
    }
}
