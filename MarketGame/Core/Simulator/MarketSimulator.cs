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
    public class MarketSimulator : IHostedService, IDisposable
    {
        private int simulationCounter = 0;
        private readonly ILogService logService;
        private readonly IGameStateManager gameStateManager;
        private readonly IGameFactory gameFactory;
        private readonly IRandomService randomService;
        private Timer _timer;

        private const int SIMULATION_FREQUENCY = 2;

        public MarketSimulator(ILogService logService, IGameStateManager gameStateManager,
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

            PlaceSellOrders();

            PlaceBuyOrders();

            ExecuteOrders();
        }

        

        private void AddCounter()
        {
            Interlocked.Increment(ref simulationCounter);
            logService.Log($"Simulating Game. Counter: {simulationCounter}");
        }

        private void PlaceSellOrders()
        {
            foreach (var person in gameStateManager.GameState.People) {

                var orders = new List<Order>();

                // Create the orders
                foreach (var stockCertificate in person.StockCertificates) {

                    orders.Add(new Order() {
                        Amount = stockCertificate.Amount,
                        OrderStatus = OrderStatus.Open,
                        OrderType = OrderType.Sell,
                        Person = person,
                        Stock = stockCertificate.Stock,
                        Value = stockCertificate.ValueWhenBought + 1
                    });
                }

                gameStateManager.GameState.Orders.AddRange(orders);
                
                foreach (var order in orders) {
                    var certificate = person.StockCertificates.Find(x => x.Stock.Name.Equals(order.Stock.Name));
                    certificate.Amount -= order.Amount;
                }

                person.ClearEmptyCertificates();
            }
        }

        private void PlaceBuyOrders()
        {
            foreach (var person in gameStateManager.GameState.People) {

                var orders = new List<Order>();

                foreach (var stock in gameStateManager.GameState.Stocks) {
                    if (randomService.PercentageCheck(10)) {
                        int amount = (int) Math.Floor(person.Money / stock.LastNegotiationPrice);
                        float buyPrice = stock.LastNegotiationPrice;

                        if (amount < 1) continue;

                        orders.Add(new Order() {
                            Amount = amount,
                            OrderStatus = OrderStatus.Open,
                            OrderType = OrderType.Buy,
                            Person = person,
                            Stock = stock,
                            Value = buyPrice
                        });

                        person.Money -= buyPrice * amount;
                    }
                }

                gameStateManager.GameState.Orders.AddRange(orders);
            }
        }

        private void ExecuteOrders()
        {
            
        }
    }
}
