using Airfield_Simulator.Core.Airplane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public class AircraftLandedEventArgs : EventArgs
    {
        public Aircraft Aircraft { get; }

        public AircraftLandedEventArgs(Aircraft ac)
        {
            this.Aircraft = ac;
        }
    }
}
