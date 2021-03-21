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
        private readonly IGameStateManager gameStateManager;
        private readonly ILogService logService;
        private readonly IRandomService randomService;


        private static int StockCounter = 0;
        private static int PersonCounter = 0;

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

            // Create stocks
            for (int i = 0; i < 5; i++) {
                gameStateManager.GameState.Stocks.Add(CreateStock());
            }

            // Create bots
            for (int i = 0; i < 5; i++) {
                
                // Create bot object
                var bot = CreateBot();

                // Give random stocks for the bot
                foreach (var stock in gameStateManager.GameState.Stocks) {
                    bot.StockCertificates.Add(new StockCertificate(){
                        Stock = stock,
                        Amount = randomService.RandomInt(0, 5),
                        BoughtDate = DateTime.Now,
                        ValueWhenBought = stock.LastNegotiationPrice
                    });
                }

                gameStateManager.GameState.Bots.Add(bot);
            }


            logService.Log("Finished initializing game");
        }

        public BotPerson CreateBot()
        {
            BotPerson bot = new BotPerson() {
                Id = PersonCounter,
                Money = randomService.RandomInt(0, 1000),
                Name = $"BOT_{PersonCounter}",
                StockCertificates = new List<StockCertificate>()
            };

            PersonCounter++;

            return bot;
        }

        public Stock CreateStock()
        {
            Stock stock = new Stock() {
                LastNegotiationPrice = randomService.RandomInt(0, 100),
                Name = $"Stock_{StockCounter}"
            };

            StockCounter++;

            return stock;
        }
    }
}
