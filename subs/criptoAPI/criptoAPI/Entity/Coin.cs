
namespace CriptoAPI.Entity
{
	public class Coin
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PriceBuy { get; set; }
        public int PriceSeller { get; set; }


        public Coin(string name, int priceBuy, int priceSeller)
        {
            Id = Guid.NewGuid();
            Name = name;
            PriceBuy = priceBuy;
            PriceSeller = priceSeller;
        }
    }
}

