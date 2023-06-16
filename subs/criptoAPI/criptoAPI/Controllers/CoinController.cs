using CriptoAPI.Data;
using CriptoAPI.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CriptoAPI.CoinController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Database.coins);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Coin coin)
        {
            coin.Id = Guid.NewGuid();
            Database.coins.Add(coin);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            Coin? coin = GetCoin(id);

            if (coin == null) return NotFound();

            Database.coins.Remove(coin);

            return Ok("Coin removida com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] Coin coin)
        {
            var editCoin = GetCoin(id);
            if (editCoin == null) return NoContent();

            editCoin.Name = coin.Name;
            editCoin.PriceBuy = coin.PriceBuy;
            editCoin.PriceSeller = coin.PriceSeller;

            return Ok(editCoin);
        }

        private Coin? GetCoin(string id)
        {
            return Database.coins.Where(coin => coin.Id.ToString().Equals(id)).FirstOrDefault();
        }
    }

}
