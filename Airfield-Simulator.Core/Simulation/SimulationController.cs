using Airfield_Simulator.Core.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Airfield_Simulator.Core.Simulation
{
    public class SimulationController : ISimulationController
    {
        public ISimulationProperties SimulationProperties { get; set; }
        public IAirplaneManager AirplaneManager { get; private set; }
        public IFlightDirector FlightDirector { get; private set; }

        private IAirplaneSpawner AirplaneSpawner { get; set; }
        public bool Running { get; private set; }

        public event AircraftLandedEventHandler AircraftLanded;



        public SimulationController(IAirplaneManager airplanemanager, IFlightDirector flightdirector, IAirplaneSpawner spawner, ISimulationProperties simprops)
        {
            AirplaneManager = airplanemanager;

            FlightDirector = flightdirector;
            SimulationProperties = simprops;
            AirplaneSpawner = spawner;

            FlightDirector.AircraftLanded += new AircraftLandedEventHandler(FlightDirector_Aircraft_Landed);
        }

        private void FlightDirector_Aircraft_Landed(object sender, AircraftLandedEventArgs e)
        {
            AirplaneManager.RemoveAircraft(e.Aircraft);
            AircraftLanded?.Invoke(this, e);
        }

        public void Init(ISimulationProperties simprops)
        {
            SimulationProperties = simprops;
            AirplaneManager.Reset();
            AirplaneSpawner.SpawnAirplane();
        }

        public void Reset()
        {
            AirplaneManager.Reset();
        }
    }
}
