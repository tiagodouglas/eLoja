using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Catalogo.Catalogo.Api.Models;

namespace Services.Catalogo.Catalogo.Api.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> SelecionaProdutos();
        Task<IEnumerable<Produto>> SelecionaProdutoPorNome(string nome);
        Task<IEnumerable<Produto>> SelecionaProdutoPorCategoria(string categoria);
        Task<Produto> SelecionaProdutoPorId(string id);
        Task InserirProduto(Produto produto);
        Task<bool> AtualizarProduto(Produto produto);
        Task<bool> ExcluirProduto(string id);
    }
}