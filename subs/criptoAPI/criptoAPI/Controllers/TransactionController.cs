using System;
using CriptoAPI.Data;
using CriptoAPI.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CriptoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Database.transactions);
        }

        [HttpGet("compras")]
        public IActionResult GetAllCompras()
        {
            var aux = Database.transactions.FindAll(transaction => transaction.TypeAction == "compra");
            return Ok(aux);
        }

        [HttpGet("vendas")]
        public IActionResult GetAllVendas()
        {
            var aux = Database.transactions.FindAll(transaction => transaction.TypeAction == "venda");
            return Ok(aux);
        }

        [HttpGet("total")]
        public IActionResult GetAllTotal()
        {
            return Ok(GetTotal());
        }

        [HttpPost("compra")]
        public IActionResult AddCompra([FromBody] Transaction transaction)
        {
            var coin = Database.coins.Find(coin => transaction.CoinName == coin.Name);
            if (transaction.CoinName != coin?.Name)
            {
                return NotFound("A moeda não foi encontrada no sistema, tente cadastrar uma ou digitar uma válida!");
            }
            else if(transaction.Quantity < 1)
            {
                return NotFound("Quantidade inválida!");
            } else
            {
                transaction.Id = Guid.NewGuid();
                var newTransaction = new Transaction(
                    transaction.CoinName,
                    transaction.Quantity,
                    transaction.Quantity * (coin.PriceBuy),
                    0,
                    new DateTime(),
                    "compra"
                    );
                Database.transactions.Add(newTransaction);
                return Ok();
            }
            
        }

        [HttpPost("venda")]
        public IActionResult AddVenda([FromBody] Transaction transaction)
        {
            var coin = Database.coins.Find(coin => transaction.CoinName == coin.Name);

            if (transaction.CoinName != coin?.Name)
            {
                return NotFound("A moeda não foi encontrada no sistema, tente cadastrar uma ou digitar uma válida!");
            }
            else if (transaction.Quantity < 1)
            {
                return NotFound("Quantidade inválida!");
            }
            else
            {
                transaction.Id = Guid.NewGuid();
                var newTransaction = new Transaction(
                    transaction.CoinName,
                    transaction.Quantity,
                    0,
                    transaction.Quantity * (coin.PriceSeller),
                    new DateTime(),
                    "venda"
                    );
                Database.transactions.Add(newTransaction);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            Transaction? transaction = GetTransaction(id);

            if (transaction == null) return NotFound();

            Database.transactions.Remove(transaction);

            return Ok("Transação removida com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] Transaction transaction)
        {
            var editTransaction = GetTransaction(id);
            if (editTransaction == null) return NoContent();

            editTransaction.CoinName = transaction.CoinName;
            editTransaction.Quantity = transaction.Quantity;
            editTransaction.PriceBuy = transaction.PriceBuy;
            editTransaction.PriceSeller = transaction.PriceSeller;
            editTransaction.Data = transaction.Data;
            editTransaction.TypeAction = transaction.TypeAction;

            return Ok(editTransaction);
        }

        private Transaction? GetTransaction(string id)
        {
            return Database.transactions.Where(transaction => transaction.Id.ToString().Equals(id)).FirstOrDefault();
        }

        private int? GetTotal()
        {
            var sumCompras = 0;
            var sumVendas = 0;
            Database.transactions.ForEach(transaction => { if (transaction.TypeAction.ToLower() == "compra") sumCompras += transaction.PriceBuy; });
            Database.transactions.ForEach(transaction => { if (transaction.TypeAction.ToLower() == "venda") sumVendas += transaction.PriceSeller; });
            return sumVendas - sumCompras;
        }
    }
}

