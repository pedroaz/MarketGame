using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Infra.Rng
{
    public class RandomService : IRandomService
    {
        private Random random = new Random(Guid.NewGuid().GetHashCode());

        public int RandomInt(int min, int max)
        {
            return random.Next(min, max+1);
        }

        public float RandomFloat(float min, float max)
        {
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }

        public bool PercentageCheck(float chance)
        {
            var value = random.NextDouble();
            return value < chance;
        }
    }
}
