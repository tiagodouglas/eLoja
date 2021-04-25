using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Services.Catalago.Catalago.Api.Data;
using Services.Catalago.Catalago.Api.Models;

namespace Services.Catalago.Catalago.Api.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ICatalogoContext _context;

        public ProdutoRepository(ICatalogoContext context)
        {
            _context = context;
        }

        public async Task<bool> AtualizarProduto(Produto produto)
        {
            var result = await _context
                .Produtos
                .ReplaceOneAsync(filter: p => p.Id == produto.Id, replacement: produto);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> ExcluirProduto(string id)
        {
            var result = await _context
              .Produtos
              .DeleteOneAsync(filter: p => p.Id == id);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task InserirProduto(Produto produto)
            => await _context
                .Produtos.InsertOneAsync(produto);

        public async Task<IEnumerable<Produto>> SelecionaProdutoPorCategoria(string categoria)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Categoria, categoria);
            return await _context
                .Produtos
                .Find(p => p.Categoria == categoria)
                .ToListAsync();
        }

        public async Task<Produto> SelecionaProdutoPorId(string id)
            => await _context
                .Produtos
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<Produto>> SelecionaProdutoPorNome(string nome)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Nome, nome);
            return await _context
                            .Produtos
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> SelecionaProdutos()
            => await _context
                .Produtos
                .Find(p => true)
                .ToListAsync();
    }
}