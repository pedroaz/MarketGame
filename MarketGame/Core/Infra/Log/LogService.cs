using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Infra.Log
{
    public class LogService : ILogService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
