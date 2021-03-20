using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Infra.Log
{
    public interface ILogService
    {
        void Log(string message);
    }
}
