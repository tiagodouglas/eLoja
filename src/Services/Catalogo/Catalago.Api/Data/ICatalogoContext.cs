using MongoDB.Driver;
using Services.Catalogo.Catalogo.Api.Models;

namespace Services.Catalogo.Catalogo.Api.Data
{
    public interface ICatalogoContext
    {
        IMongoCollection<Produto> Produtos { get; }
    }
}