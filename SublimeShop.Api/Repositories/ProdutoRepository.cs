using Microsoft.EntityFrameworkCore;
using SublimeShop.Api.Context;
using SublimeShop.Api.Entities;
using SublimeShop.Api.IRepositories;

namespace SublimeShop.Api.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Produto> GetProduto(int id)
        {
            var produto = await GetAll()
                .Include(c => c.Categoria)
                .SingleOrDefaultAsync(c => c.ProdutoId == id);
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetProdutoPorCategoria(int id)
        {
            var produtos = await GetAll()
                .Include(x => x.Categoria)
                .Where(x => x.CategoriaId == id)
                .ToListAsync();

            return produtos;
        }

        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            var produtos = await GetAll().Include(p => p.Categoria)
                .ToListAsync();
            return produtos;
        }
    }
}
