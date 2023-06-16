using System;
using CriptoAPI.Entity;

namespace CriptoAPI.Data
{
	public class Database
	{
        public static List<Coin> coins = new List<Coin>() {
            new Coin("bitcoin", 1500, 1200),
            new Coin("ethereum", 1000, 800),
            new Coin("binance-coin", 100, 120),

        };

        public static List<Transaction> transactions = new List<Transaction>() {
            new Transaction("bitcoin", 3, 4500, 0, new DateTime(), "compra"),
            new Transaction("ethereum", 2, 2000, 0, new DateTime(), "compra"),
            new Transaction("binance-coin", 1, 0, 100, new DateTime(), "venda"),
        };
    }
}

