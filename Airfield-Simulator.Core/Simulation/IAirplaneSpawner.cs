using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public interface IAirplaneSpawner
    {
        event AirplaneSpawnEventHandler AirplaneSpawn;
        void SpawnAirplane();
    }
}
