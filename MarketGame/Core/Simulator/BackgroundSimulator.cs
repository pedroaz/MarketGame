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
            
        }

        private void PlaceBuyOrders()
        {
            
        }

        private void ExecuteOrders()
        {
            
        }
    }
}
