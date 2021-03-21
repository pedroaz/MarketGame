using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Initializer
{
    public interface IGameFactory
    {
        Task InitializeGame();
    }
}
