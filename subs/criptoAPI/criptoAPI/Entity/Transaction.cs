using System;
namespace CriptoAPI.Entity
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string CoinName { get; set; }
        public int Quantity { get; set; }
        public int PriceBuy { get; set; }
        public int PriceSeller { get; set; }
        public DateTime Data { get; set; }
        public string TypeAction { get; set; }


        public Transaction(string coinName, int quantity, int priceBuy, int priceSeller, DateTime data, string typeAction)
        {
            Id = Guid.NewGuid();
            CoinName = coinName;
            Quantity = quantity;
            PriceBuy = priceBuy;
            PriceSeller = priceSeller;
            Data = data;
            TypeAction = typeAction;
        }
    }
}

