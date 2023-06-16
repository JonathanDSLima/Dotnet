using System;
namespace app_cripto_ui.Model
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
    }
}

