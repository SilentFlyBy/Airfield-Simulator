using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public interface ITimer
    {
        int Interval { get; set; }

        event EventHandler Tick;

        void Start();
        void Stop();
    }
}
