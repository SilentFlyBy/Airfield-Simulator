using Airfield_Simulator.Core.Airplane;
using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public interface IAirplaneManager
    {
        List<Aircraft> AircraftList { get; }

        event CollisionEventHandler Collision;

        Aircraft CreateAircraft(GeoPoint position);
        void RemoveAircraft(Aircraft aircaft);
        void Reset();
    }
}
