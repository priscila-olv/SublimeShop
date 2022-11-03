﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SublimeShop.Api.Context;

#nullable disable

namespace SublimeShop.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221010201242_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SublimeShop.Api.Entities.Carrinho", b =>
                {
                    b.Property<int>("CarrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrinhoId"), 1L, 1);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("CarrinhoId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Carrinhos");
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.CarrinhoProduto", b =>
                {
                    b.Property<int>("CarrinhoProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrinhoProdutoId"), 1L, 1);

                    b.Property<int>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("CarrinhoProdutoId");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("CarrinhoProdutos");
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("IconCategoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            IconCategoria = "FotoiconBlusa",
                            NomeCategoria = "Blusas"
                        },
                        new
                        {
                            CategoriaId = 2,
                            IconCategoria = "FotoiconCalca",
                            NomeCategoria = "Calças"
                        });
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoProduto")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ImagemUrl")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeProduto")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("PrecoProduto")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("QuantidadeProduto")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ProdutoId = 1,
                            CategoriaId = 1,
                            DescricaoProduto = "Blusa básica preta, tecido viscose",
                            ImagemUrl = "/Images/Produtos/Blusas/BlusaBasica.png",
                            NomeProduto = "Blusa básica",
                            PrecoProduto = 30m,
                            QuantidadeProduto = 52
                        },
                        new
                        {
                            ProdutoId = 2,
                            CategoriaId = 1,
                            DescricaoProduto = "Blusa Mickey, tecido viscose",
                            ImagemUrl = "/Images/Produtos/Blusas/BlusaMickey.png",
                            NomeProduto = "Blusa Mickey",
                            PrecoProduto = 40m,
                            QuantidadeProduto = 15
                        },
                        new
                        {
                            ProdutoId = 3,
                            CategoriaId = 1,
                            DescricaoProduto = "Blusa de linho, nova tendência da moda amigas",
                            ImagemUrl = "/Images/Produtos/Blusas/BlusaLinho.png",
                            NomeProduto = "Blusa Linho",
                            PrecoProduto = 60m,
                            QuantidadeProduto = 27
                        },
                        new
                        {
                            ProdutoId = 4,
                            CategoriaId = 2,
                            DescricaoProduto = "Calça Jeans Skinny PitBull",
                            ImagemUrl = "/Images/Produtos/Calças/CalçaSkinny.png",
                            NomeProduto = "Calça Jeans Skinny",
                            PrecoProduto = 160m,
                            QuantidadeProduto = 3
                        });
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            NomeUsuario = "Administrator"
                        });
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.Carrinho", b =>
                {
                    b.HasOne("SublimeShop.Api.Entities.Usuario", null)
                        .WithOne("Carrinho")
                        .HasForeignKey("SublimeShop.Api.Entities.Carrinho", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.CarrinhoProduto", b =>
                {
                    b.HasOne("SublimeShop.Api.Entities.Carrinho", "Carrinho")
                        .WithMany("CarrinhoProdutos")
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SublimeShop.Api.Entities.Produto", "Produto")
                        .WithMany("CarrinhoProdutos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrinho");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.Produto", b =>
                {
                    b.HasOne("SublimeShop.Api.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.Carrinho", b =>
                {
                    b.Navigation("CarrinhoProdutos");
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.Produto", b =>
                {
                    b.Navigation("CarrinhoProdutos");
                });

            modelBuilder.Entity("SublimeShop.Api.Entities.Usuario", b =>
                {
                    b.Navigation("Carrinho");
                });
#pragma warning restore 612, 618
        }
    }
}