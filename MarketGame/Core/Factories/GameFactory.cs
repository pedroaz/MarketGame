using MarketGame.Core.Infra.Log;
using MarketGame.Core.Infra.Rng;
using MarketGame.Core.Models.Market;
using MarketGame.Core.Models.People;
using MarketGame.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Initializer
{
    public class GameFactory : IGameFactory
    {


        private const int INITIAL_AMOUNT_OF_STOCKS = 1;
        private const int INITIAL_AMOUNT_OF_BOTS = 5;



        private readonly IGameStateManager gameStateManager;
        private readonly ILogService logService;
        private readonly IRandomService randomService;


        private static int StockCounter = 0;

        public GameFactory(IGameStateManager gameStateManager, ILogService logService, IRandomService randomService)
        {
            this.gameStateManager = gameStateManager;
            this.logService = logService;
            this.randomService = randomService;
        }

        public async Task InitializeGame()
        {
            logService.Log("Starting to initialize game");
            gameStateManager.GameState = new GameState();

            // Create GOD
            gameStateManager.GameState.God = new Person();

            // Create stocks
            for (int i = 0; i < INITIAL_AMOUNT_OF_STOCKS; i++) {
                gameStateManager.GameState.Stocks.Add(CreateStock());
            }

            // Create bots
            for (int i = 0; i < INITIAL_AMOUNT_OF_BOTS; i++) {
                
                // Create bot object
                var bot = new Person(randomService.RandomInt(0, 1000));

                // Give random stocks for the bot
                foreach (var stock in gameStateManager.GameState.Stocks) {
                    var amount = randomService.RandomInt(0, 5);
                    if (amount == 0) continue;
                    bot.AddStockCertificate(stock, amount);
                    gameStateManager.GameState.Negotiations.Add(new Negotiation(stock, bot, gameStateManager.GameState.God, amount, 0));
                }

                bot.ClearEmptyCertificates();

                gameStateManager.GameState.People.Add(bot);
            }


            logService.Log("Finished initializing game");
        }

        public Stock CreateStock()
        {
            Stock stock = new Stock() {
                LastNegotiationPrice = decimal.Round(randomService.RandomDecimal(0, 100),2),
                Name = $"Stock_{StockCounter}"
            };

            StockCounter++;

            return stock;
        }
    }
}
