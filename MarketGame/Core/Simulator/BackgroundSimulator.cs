using MarketGame.Core.Infra.Log;
using MarketGame.Core.Infra.Rng;
using MarketGame.Core.Initializer;
using MarketGame.Core.Models.Market;
using MarketGame.Core.State;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MarketGame.Core.Simulator
{
    public class BackgroundSimulator : IHostedService, IDisposable
    {
        private int simulationCounter = 0;
        private readonly ILogService logService;
        private readonly IGameStateManager gameStateManager;
        private readonly IGameFactory gameFactory;
        private readonly IRandomService randomService;
        private Timer _timer;

        private const int SIMULATION_FREQUENCY = 2;

        public BackgroundSimulator(ILogService logService, IGameStateManager gameStateManager,
            IGameFactory gameFactory, IRandomService randomService)
        {
            this.logService = logService;
            this.gameStateManager = gameStateManager;
            this.gameFactory = gameFactory;
            this.randomService = randomService;
        }

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            logService.Log("Timed Hosted Service running.");

            await gameFactory.InitializeGame();

            _timer = new Timer(SimulateGame, null, TimeSpan.Zero, TimeSpan.FromSeconds(SIMULATION_FREQUENCY));
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            logService.Log("Simulation is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void SimulateGame(object state)
        {
            AddCounter();

            CleanUp();

            PlaceSellOrders();

            PlaceBuyOrders();

            ExecuteOrders();
        }

        

        private void AddCounter()
        {
            Interlocked.Increment(ref simulationCounter);
            logService.Log($"Simulating Game. Counter: {simulationCounter}");
        }

        private void CleanUp()
        {
            foreach (var person in gameStateManager.GameState.Bots) {

                var zeroStocks = new List<string>();

                foreach (var kvp in person.Stocks) {
                    if (kvp.Value < 1) {
                        zeroStocks.Add(kvp.Key);
                    }
                }

                foreach (var stockName in zeroStocks) {
                    person.Stocks.Remove(stockName);
                }
            }
        }

        private void PlaceBuyOrders()
        {
            foreach (var bot in gameStateManager.GameState.Bots) {

                foreach (var stock in gameStateManager.GameState.Stocks) {

                    // 10% to want to buy
                    if (randomService.PercentageCheck(0.1f)) {

                    }
                }
            }
        }

        private void PlaceSellOrders()
        {
            foreach (var bot in gameStateManager.GameState.Bots) {

                var listOfSellOffers = new List<Order>();

                foreach (var kvp in bot.Stocks) {

                    // 20% to sell all
                    if (randomService.PercentageCheck(0.2f)) {
                        string stockName = kvp.Key;
                        int amountToSell = kvp.Value;

                        var stock = gameStateManager.GameState.Stocks.Find(x => x.Name.Equals(stockName));
                        var sellStockOffer = new Order() {
                            OrderType = OrderType.Sell,
                            Stock = stock,
                            Amount = amountToSell,
                            Person = bot,
                            Value = stock.LastNegotiationPrice + randomService.RandomFloat(-1, 1)
                        };
                        listOfSellOffers.Add(sellStockOffer);
                        gameStateManager.GameState.Orders.Add(sellStockOffer);
                    }
                }

                // Remove from person immediatlly
                foreach (var sellOffer in listOfSellOffers) {
                    bot.Stocks[sellOffer.Stock.Name] -= sellOffer.Amount;
                }
            }
        }

        private void ExecuteOrders()
        {
            
        }
    }
}
