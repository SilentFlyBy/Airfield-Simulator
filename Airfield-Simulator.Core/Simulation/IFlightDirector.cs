using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public interface IFlightDirector
    {
        int InstructionsPerMinute { get; }

        void Init();
        void Start();
        void Stop();
    }
}
