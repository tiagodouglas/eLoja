using MongoDB.Driver;
using Services.Catalago.Catalago.Api.Models;

namespace Services.Catalago.Catalago.Api.Data
{
    public interface ICatalogoContext
    {
        IMongoCollection<Produto> Produtos { get; }
    }
}