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

        [HttpGet("People")]
        public IActionResult People()
        {
            return Ok(gameStateManager.GameState.People);
        }

        [HttpGet("PeopleById")]
        public IActionResult PeopleById(int id)
        {
            return Ok(gameStateManager.GameState.People.Where(x => x.Id.Equals(id)));
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
