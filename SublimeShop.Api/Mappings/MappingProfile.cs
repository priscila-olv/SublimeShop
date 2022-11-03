using AutoMapper;
using SublimeShop.Api.Entities;
using SublimeShop.Models.DTOs;

namespace SublimeShop.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(dest => dest.CategoriaNome,
                op => op.MapFrom(scr => scr.Categoria.NomeCategoria));

            CreateMap<CarrinhoProduto, CarrinhoProdutoAdicionaDto>().ReverseMap();

            CreateMap<CarrinhoProduto, CarrinhoProdutoDTO>().
                ForMember(dest => dest.PrecoTotal,
                op => op.MapFrom(scr => scr.Produto.PrecoProduto * scr.Quantidade));
        }
    }   
}
