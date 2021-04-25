using System.Collections.Generic;
using MongoDB.Driver;
using Services.Catalago.Catalago.Api.Models;

namespace Services.Catalago.Catalago.Api.Data
{
    public class CatalogoContextSeed
    {
        public static void SeedData(IMongoCollection<Produto> produtoCollection)
        {
            var existeProduto = produtoCollection.Find(p => true).Any();

            if (!existeProduto)
            {
                produtoCollection.InsertManyAsync(SelecionaProdutos());
            }

        }

        private static IEnumerable<Produto> SelecionaProdutos()
        {
            return new List<Produto>()
            {
                new Produto()
                {
                    Nome = "Notebook 1",
                    Sumario = "Lorem ipsum dolor sit amet, consectetur adipisicing elit",
                    Categoria = "Computadores",
                    Descricao = "Lorem ipsum dolor sit amet, consectetur adipisicing elit",
                    Imagem = "notebook-1.png",
                    Preco = 4999
                },
                new Produto()
                {
                    Nome = "Notebook 2",
                    Sumario = "Lorem ipsum dolor sit amet, consectetur adipisicing elit",
                    Categoria = "Computadores",
                    Descricao = "Lorem ipsum dolor sit amet, consectetur adipisicing elit",
                    Imagem = "notebook-2.png",
                    Preco = 3999
                },
                new Produto()
                {
                    Nome = "Notebook 3",
                    Sumario = "Lorem ipsum dolor sit amet, consectetur adipisicing elit",
                    Categoria = "Computadores",
                    Descricao = "Lorem ipsum dolor sit amet, consectetur adipisicing elit",
                    Imagem = "notebook-1.png",
                    Preco = 2999
                }
            };
        }
    }
}