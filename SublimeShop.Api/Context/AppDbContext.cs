
using Microsoft.EntityFrameworkCore;
using SublimeShop.Api.Entities;

namespace SublimeShop.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }
        public DbSet<Carrinho>? Carrinhos { get; set; }
        public DbSet<CarrinhoProduto>? CarrinhoProdutos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            { 
                CategoriaId = 1,
                NomeCategoria = "Blusas",
                IconCategoria = "FotoiconBlusa"

            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                CategoriaId = 2,
                NomeCategoria = "Calças",
                IconCategoria = "FotoiconCalca"

            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 1,
                NomeProduto = "Blusa básica",
                DescricaoProduto = "Blusa básica preta, tecido viscose",
                ImagemUrl = "/Images/Produtos/Blusas/BlusaBasica.png",
                PrecoProduto = 30,
                QuantidadeProduto = 52,
                CategoriaId = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 2,
                NomeProduto = "Blusa Mickey",
                DescricaoProduto = "Blusa Mickey, tecido viscose",
                ImagemUrl = "/Images/Produtos/Blusas/BlusaMickey.png",
                PrecoProduto = 40,
                QuantidadeProduto = 15,
                CategoriaId = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 3,
                NomeProduto = "Blusa Linho",
                DescricaoProduto = "Blusa de linho, nova tendência da moda amigas",
                ImagemUrl = "/Images/Produtos/Blusas/BlusaLinho.png",
                PrecoProduto = 60,
                QuantidadeProduto = 27,
                CategoriaId = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 4,
                NomeProduto = "Calça Jeans Skinny",
                DescricaoProduto = "Calça Jeans Skinny PitBull",
                ImagemUrl = "/Images/Produtos/Calças/CalçaSkinny.png",
                PrecoProduto = 160,
                QuantidadeProduto = 3,
                CategoriaId = 2
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                UsuarioId = 1,
                NomeUsuario = "Administrator"
            });
        }
    }
}
