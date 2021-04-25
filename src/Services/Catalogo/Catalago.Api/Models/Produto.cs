using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Services.Catalogo.Catalogo.Api.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Sumario { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
    }
}