using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public interface ISimulationController
    {
        IAirplaneManager AirplaneManager { get; }
        IFlightDirector FlightDirector { get; }

        event AircraftLandedEventHandler AircraftLanded;


        void Init(ISimulationProperties simprops);
    }
}
