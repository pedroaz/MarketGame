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

        private const int SIMULATION_FREQUENCY = 10;

        private int SIMULATION_COUNTER = 0;
        private readonly ILogService logService;
        private readonly IGameStateManager gameStateManager;
        private readonly IGameFactory gameFactory;
        private readonly IRandomService randomService;
        private Timer _timer;


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
            if(gameStateManager.GameState.ManualSimulationCounter > 0) {
                gameStateManager.GameState.ManualSimulationCounter--;
            }
            else if (!gameStateManager.GameState.AutoSimulation) {
                return;
            }

            AddCounter();

            PlaceSellOrders();

            PlaceBuyOrders();

            ExecuteOrders();
        }

        

        private void AddCounter()
        {
            Interlocked.Increment(ref SIMULATION_COUNTER);
            logService.Log($"Simulating Game. Counter: {SIMULATION_COUNTER}");
        }

        private void PlaceSellOrders()
        {
            foreach (var person in gameStateManager.GameState.People) {

                var orders = new List<Order>();

                // Create the orders
                foreach (var stockCertificate in person.StockCertificates) {

                    var value = decimal.Round(stockCertificate.Stock.LastNegotiationPrice + randomService.RandomDecimal(-0.1M, 0.1M), 2);
                    var amount = randomService.RandomInt(0, stockCertificate.Amount);
                    orders.Add(new Order(OrderType.Sell, stockCertificate.Stock, amount, value, person));
                }

                // Add order the game manager
                gameStateManager.GameState.Orders.AddRange(orders);
                
                // Remove the stocks from the person
                foreach (var order in orders) {
                    var certificate = person.StockCertificates.Find(x => x.Stock.Name.Equals(order.Stock.Name));
                    certificate.Amount -= order.Amount;
                }

                // Clean the stock certificates if he has no amount of that stock
                person.ClearEmptyCertificates();
            }
        }

        private void PlaceBuyOrders()
        {
            foreach (var person in gameStateManager.GameState.People) {

                var orders = new List<Order>();

                foreach (var stock in gameStateManager.GameState.Stocks) {
                    
                    // Random change to buy
                    if (randomService.PercentageCheck(10)) {

                        // Try to buy the max he cans of that stock
                        int amount = (int) Math.Floor(person.Money / stock.LastNegotiationPrice);
                        decimal buyPrice = decimal.Round(stock.LastNegotiationPrice + randomService.RandomDecimal(-0.1M, 0.1M), 2);

                        if (amount < 1) continue;

                        // Add new order
                        gameStateManager.GameState.Orders.Add(new Order(OrderType.Buy, stock, amount, buyPrice, person));

                        // Remove money from the person as soon as he places the order - probabbly will need to change this later
                        person.Money -= buyPrice * amount;
                    }
                }

                
            }
        }

        private void ExecuteOrders()
        {
            foreach (var buyOrder in gameStateManager.GameState.Orders.Where(x => x.OrderType.Equals(OrderType.Buy))) {

                // Find all sell orders which match the stock and are open
                var sellOrders = gameStateManager.GameState.Orders.Where(
                    x => x.OrderType.Equals(OrderType.Sell) &&
                    x.Stock.Name.Equals(buyOrder.Stock.Name) &&
                    x.OrderStatus.Equals(OrderStatus.Open)
                );

                foreach (var sellOrder in sellOrders) {

                    if (buyOrder.OrderStatus.Equals(OrderStatus.Executed)) break;

                    // The buyer is trying to buy for less than the seller is trying to sell
                    if (buyOrder.Value < sellOrder.Value) continue;

                    int amountToChange = 0;
                    decimal negociationPrice = sellOrder.Value;

                    // Buy orders has more or they are the same.
                    // Lets buy all from the sell order then
                    if(buyOrder.AmountRemaining >= sellOrder.AmountRemaining) {
                        amountToChange = sellOrder.AmountRemaining;
                    }
                    // Sell order has more. Lets buy all we can form the sale order
                    else if (buyOrder.AmountRemaining < sellOrder.AmountRemaining) {
                        amountToChange = buyOrder.AmountRemaining;
                    }

                    if (amountToChange == 0) continue;

                    // Remove amount from the orders
                    buyOrder.AmountRemaining -= amountToChange;
                    sellOrder.AmountRemaining -= amountToChange;

                    // Add stock the buyer
                    buyOrder.Person.AddStockCertificate(buyOrder.Stock, amountToChange);

                    // Add money to seller
                    sellOrder.Person.Money += amountToChange * negociationPrice;

                    if (buyOrder.AmountRemaining == 0) buyOrder.OrderStatus = OrderStatus.Executed;
                    if (sellOrder.AmountRemaining == 0) sellOrder.OrderStatus = OrderStatus.Executed;

                    var negotiation = new Negotiation(buyOrder.Stock, buyOrder.Person, sellOrder.Person, amountToChange, negociationPrice);
                    gameStateManager.GameState.Negotiations.Add(negotiation);
                }
            }
        }
    }
}
