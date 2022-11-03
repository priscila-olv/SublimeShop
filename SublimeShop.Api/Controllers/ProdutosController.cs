using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SublimeShop.Api.Entities;
using SublimeShop.Api.IRepositories;
using SublimeShop.Models.DTOs;

namespace SublimeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public ProdutosController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetProdutoPorCategoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutoPorCategoria(int categoriaId)
        {
            var produtos = await _context.ProdutoRepository.GetProdutoPorCategoria(categoriaId);
            var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);
            return Ok(produtosDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutos()
        {
            var produtos = await _context.ProdutoRepository
                .GetProdutos();
            var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);

            return Ok(produtosDto);
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> GetById(int id)
        {
            var produto = await _context.ProdutoRepository
                .GetById(p => p.ProdutoId == id);
            if (produto == null)
                return NotFound();

            var produtosDto = _mapper.Map<ProdutoDTO>(produto);

            return Ok(produtosDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);

            _context.ProdutoRepository.Post(produto);
            await _context.Commit();

            var _produtoDto = _mapper.Map<ProdutoDTO>(produto);

            return new CreatedAtRouteResult("GetProduto",
                new { id = produto.ProdutoId }, _produtoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (id != produtoDto.ProdutoId)
                return BadRequest();

            var produto = _mapper.Map<Produto>(produtoDto);
            _context.ProdutoRepository.Update(produto);
            await _context.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produto = await _context.ProdutoRepository
                .GetById(p => p.ProdutoId == id);
            if (produto is null)
                return NotFound();

            _context.ProdutoRepository.Delete(produto);
            await _context.Commit();
            var produtoDto = _mapper.Map<ProdutoDTO>(produto);

            return produtoDto;
        }
    }
}
