using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Infra.Rng
{
    public interface IRandomService
    {
        int RandomInt(int min, int max);
        float RandomFloat(float min, float max);
        bool PercentageCheck(float chance);
    }
}
