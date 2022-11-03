using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SublimeShop.Api.IRepositories;
using SublimeShop.Models.DTOs;

namespace SublimeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private IMapper _mapper;

        private ILogger<CarrinhoController> _logger;

        public CarrinhoController(IUnitOfWork context, IMapper mapper, ILogger<CarrinhoController> logger)
        {
            _uof = context;
            _mapper = mapper;
            this._logger = logger;
        }

        [HttpGet]
        [Route("{usuarioId}/GetProdutos")]
        public async Task<ActionResult<IEnumerable<CarrinhoProdutoDTO>>> GetItens(string usuarioid)
        {
            try
            {
                var carrinhoProdutos = await _uof.CarrinhoRepository.GetProdutos(usuarioid);
                if (carrinhoProdutos == null)
                    return NoContent();


                var produtos = await this._uof.ProdutoRepository.GetProdutos();
                if (produtos == null)
                {
                    throw new Exception("Não existem itens...");
                }

                var carrinhoProdutosDto = _mapper.Map<List<CarrinhoProdutoDTO>>(produtos);
                return Ok(carrinhoProdutosDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao obter itens do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarrinhoProdutoDTO>> GetProduto(int id)
        {
            try
            {
                var carrinhoProduto = await _uof.CarrinhoRepository.GetProduto(id);
                if (carrinhoProduto is null)
                    return NotFound($"Produto não encontrado");

                var produto = await _uof.ProdutoRepository.GetProduto(carrinhoProduto.ProdutoId);

                if (produto is null)
                    return NotFound($"Item não existe na fonte de dados");

                var carrinhoProdutoDto = _mapper.Map<CarrinhoProdutoDTO>(produto);
                return Ok(carrinhoProdutoDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"## Erro ao obter o item ={id} do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<CarrinhoProdutoDTO>> PostProduto
        //    ([FromBody] CarrinhoProdutoAdicionaDto carrinhoProdutoAdicionaDto)
        //{
        //    try
        //    {
        //        var novoCarrinhoProduto = await _uof.CarrinhoRepository.AddProduto(carrinhoProdutoAdicionaDto);
        //        if (novoCarrinhoProduto == null)
        //            return NoContent();

        //        var produto = _uof.ProdutoRepository.GetProduto(novoCarrinhoProduto.ProdutoId);

        //        if (produto is null)
        //            throw new Exception($"Produto não localizado - Produto Id:{carrinhoProdutoAdicionaDto.ProdutoId}");
        //        var novoCarrinhoItemDto = _mapper.Map<CarrinhoProdutoAdicionaDto>(produto);

        //        return CreatedAtAction(nameof(GetProduto), new { id = novoCarrinhoItemDto.CarrinhoId }, novoCarrinhoItemDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("## Erro criar um novo item no carrinho");
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
    }
}
