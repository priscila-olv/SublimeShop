using SublimeShop.Api.Context;
using SublimeShop.Api.IRepositories;
using SublimeShop.Api.Repositories.IRepositories;

namespace SublimeShop.Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProdutoRepository _produtoRepository;
        private CarrinhoRepository _carrinhoRepository;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository 
        { 
            get 
            {
                return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);
            }
        }

        public ICarrinhoRepository CarrinhoRepository
        {
            get
            {
                return _carrinhoRepository = _carrinhoRepository ?? new CarrinhoRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

    }
}
