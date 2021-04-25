using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Catalogo.Catalogo.Api.Models;
using Services.Catalogo.Catalogo.Api.Repositories;

namespace Services.Catalogo.Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<CatalogoController> _logger;

        public CatalogoController(IProdutoRepository produtoRepository, ILogger<CatalogoController> logger)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Produto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Produto>>> SelecionaProdutos()
        {
            var produtos = await _produtoRepository.SelecionaProdutos();

            return Ok(produtos);
        }

        [HttpGet("{id:length(24)}", Name = "SelecionaProdutoPorId")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Produto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Produto>> SelecionaProdutoPorId(string id)
        {
            var produto = await _produtoRepository.SelecionaProdutoPorId(id);
            if (produto == null)
            {
                _logger.LogError($"Produto não encontrado: {id}");
                return NotFound();
            }
            return Ok(produto);
        }

        [Route("Categoria", Name = "SelecionaProdutoPorCategoria")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Produto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Produto>>> SelecionaProdutoPorCategoria(string categoria)
        {
            var produtos = await _produtoRepository.SelecionaProdutoPorCategoria(categoria);
            return Ok(produtos);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Produto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Produto>> InserirProduto([FromBody] Produto produto)
        {
            await _produtoRepository.InserirProduto(produto);
            return CreatedAtRoute("SelecionaProdutoPorId", new { id = produto.Id }, produto);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Produto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AtualizarProduto([FromBody] Produto produto)
        {
            return Ok(await _produtoRepository.AtualizarProduto(produto));
        }

        [HttpDelete("{id:length(24)}", Name = "ExcluirProduto")]
        [ProducesResponseType(typeof(Produto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ExcluirProduto(string id)
        {
            return Ok(await _produtoRepository.ExcluirProduto(id));
        }
    }
}