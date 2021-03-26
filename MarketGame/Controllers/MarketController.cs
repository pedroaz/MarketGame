using MarketGame.Core.Models.Market;
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

        [HttpGet("EnableSimulation")]
        public ActionResult<IEnumerable<Person>> EnableSimulation()
        {
            gameStateManager.GameState.AutoSimulation = true;
            return Ok();
        }

        [HttpGet("DisableSimulation")]
        public ActionResult<IEnumerable<Person>> DisableSimulation()
        {
            gameStateManager.GameState.AutoSimulation = false;
            return Ok();
        }

        [HttpGet("AddManualSimulation")]
        public ActionResult<IEnumerable<Person>> AddManualSimulation()
        {
            gameStateManager.GameState.ManualSimulationCounter++;
            return Ok();
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

        [HttpGet("Orders")]
        public ActionResult<IEnumerable<Order>> Orders()
        {
            return Ok(gameStateManager.GameState.Orders);
        }

        [HttpGet("Negotations")]
        public ActionResult<IEnumerable<Negotiation>> Negotations()
        {
            return Ok(gameStateManager.GameState.Negotiations);
        }

        [HttpGet("NegotationsFromPerson")]
        public ActionResult<IEnumerable<Negotiation>> NegotationsFromPerson(int id)
        {
            return Ok(gameStateManager.GameState.Negotiations.Where(x => x.Buyer.Id == id || x.Seller.Id == id));
        }


    }
}
