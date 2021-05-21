namespace Services.Carrinho.Carrinho.Api.Models
{
    public class CarrinhoCompraItem
    {
        public int Quantidade { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public string IdProduto { get; set; }
        public string NomeProduto { get; set; }
        
    }
}