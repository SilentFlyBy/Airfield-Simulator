using Airfield_Simulator.Core.Airplane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public class AirplaneSpawnEventArgs : EventArgs
    {
        public Aircraft SpawnedAircraft { get; set; }

        public AirplaneSpawnEventArgs(Aircraft aircraft)
        {
            this.SpawnedAircraft = aircraft;
        }
    }
}
