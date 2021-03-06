using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Services.Catalogo.Catalogo.Api.Models;

namespace Services.Catalogo.Catalogo.Api.Data
{
    public class CatalogoContext : ICatalogoContext
    {
        public CatalogoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Produtos = database.GetCollection<Produto>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogoContextSeed.SeedData(Produtos);
        }

        public IMongoCollection<Produto> Produtos { get; }
    }
}