using System;

namespace Carrinho.Api.Models
{
    public class CarrinhoCompra
    {
        public string Usuario { get; set; }
        public List<CarrinhoCompraItem> Itens { get; set; } = new List<CarrinhoCompraItem>();

        public decimal Total
        {
            get 
            {
                var total = 0;

                foreach (var item in Itens)
                    total += item.Preco * item.Quantidade;

                return total;
            }
        }
    }
}
