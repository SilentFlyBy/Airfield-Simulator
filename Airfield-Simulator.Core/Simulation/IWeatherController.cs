using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public interface IWeatherController
    {
        int WindDegrees { get; }
    }
}
