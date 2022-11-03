using Microsoft.EntityFrameworkCore;
using SublimeShop.Api.Context;
using SublimeShop.Api.Entities;
using SublimeShop.Api.Repositories.IRepositories;
using SublimeShop.Models.DTOs;

namespace SublimeShop.Api.Repositories
{
    public class CarrinhoRepository : Repository<CarrinhoProduto>, ICarrinhoRepository
    {
        private readonly AppDbContext _context;
        public CarrinhoRepository(AppDbContext context) : base(context)
        {
        }

        private async Task<bool> CarrinhoProdutoExiste(int carrinhoId, int produtoId)
        {
            return await _context.CarrinhoProdutos
                .AnyAsync(c => c.CarrinhoId == carrinhoId && c.ProdutoId == produtoId);
        }

        public async Task<CarrinhoProduto> GetProduto(int id)
        {
            return await (from carrinho in _context.Carrinhos
                          join carrinhoProduto in _context.CarrinhoProdutos
                          on carrinho.CarrinhoId equals carrinhoProduto.CarrinhoId
                          where carrinhoProduto.CarrinhoProdutoId == id
                          select new CarrinhoProduto
                          {
                              CarrinhoProdutoId = carrinhoProduto.CarrinhoProdutoId,
                              ProdutoId = carrinhoProduto.ProdutoId,
                              Quantidade = carrinhoProduto.Quantidade,
                              CarrinhoId = carrinhoProduto.CarrinhoId

                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CarrinhoProduto>> GetProdutos(string usuarioId)
        {
            return await (from carrinho in _context.Carrinhos
                          join carrinhoProduto in _context.CarrinhoProdutos
                          on carrinho.CarrinhoId equals carrinhoProduto.CarrinhoId
                          where carrinho.UsuarioId == usuarioId
                          select new CarrinhoProduto
                          {
                              CarrinhoProdutoId = carrinhoProduto.CarrinhoProdutoId,
                              ProdutoId = carrinhoProduto.ProdutoId,
                              Quantidade = carrinhoProduto.Quantidade,
                              CarrinhoId = carrinhoProduto.CarrinhoId
                          }).ToListAsync();

        }



        public async Task<CarrinhoProduto> AddProduto(CarrinhoProdutoAdicionaDto carrinhoProdutoAdicionaDto)
        {
            if (await CarrinhoProdutoExiste(carrinhoProdutoAdicionaDto.CarrinhoId,
                carrinhoProdutoAdicionaDto.ProdutoId) == false)
            {
                var item = await (from produto in _context.Produtos
                                  where produto.ProdutoId == carrinhoProdutoAdicionaDto.ProdutoId
                                  select new CarrinhoProduto
                                  {
                                      CarrinhoId = carrinhoProdutoAdicionaDto.CarrinhoId,
                                      ProdutoId = produto.ProdutoId,
                                      Quantidade = carrinhoProdutoAdicionaDto.Quantidade
                                  }).SingleOrDefaultAsync();

                if (item is not null)
                {
                    var result = await _context.CarrinhoProdutos.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }
    }
}
