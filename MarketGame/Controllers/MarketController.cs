﻿using MarketGame.Core.Models.Market;
using MarketGame.Core.Models.People;
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
        public ActionResult<IEnumerable<Person>> People()
        {
            return Ok(gameStateManager.GameState.People);
        }

        [HttpGet("PeopleById")]
        public ActionResult<Person> PeopleById(int id)
        {
            return Ok(gameStateManager.GameState.People.Where(x => x.Id.Equals(id)).FirstOrDefault());
        }

        [HttpGet("SellOrders")]
        public ActionResult<IEnumerable<Order>> SellOrders()
        {
            return Ok(gameStateManager.GameState.Orders.Where(x => x.OrderType.Equals(OrderType.Sell)));
        }

        [HttpGet("BuyOrders")]
        public ActionResult<IEnumerable<Order>> BuyOrders()
        {
            return Ok(gameStateManager.GameState.Orders.Where(x => x.OrderType.Equals(OrderType.Buy)));
        }
    }
}
