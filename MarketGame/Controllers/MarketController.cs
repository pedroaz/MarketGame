using MarketGame.Core.Models.Market;
using MarketGame.Core.State;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Controllers
{
    [Route("api/")]
    public class MarketController : ControllerBase
    {
        private readonly IGameStateManager gameStateManager;

        public MarketController(IGameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
        }

        [HttpGet("Bots")]
        public IActionResult Bots()
        {
            return Ok(gameStateManager.GameState.Bots);
        }

        [HttpGet("BotById")]
        public IActionResult BotById(int id)
        {
            return Ok(gameStateManager.GameState.Bots.Where(x => x.Id.Equals(id)));
        }

        [HttpGet("SellOrders")]
        public IActionResult SellOrders()
        {
            return Ok(gameStateManager.GameState.Orders.Where(x => x.OrderType.Equals(OrderType.Sell)));
        }

        [HttpGet("BuyOrders")]
        public IActionResult BuyOrders()
        {
            return Ok(gameStateManager.GameState.Orders.Where(x => x.OrderType.Equals(OrderType.Buy)));
        }
    }
}
