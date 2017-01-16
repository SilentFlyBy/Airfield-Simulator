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
        public IAirplaneSpawner AirplaneSpawner { get; private set; }

        public bool Running { get; private set; }


        public SimulationController(IAirplaneManager airplanemanager, IFlightDirector flightdirector, IAirplaneSpawner spawner, ISimulationProperties simprops)
        {
            this.AirplaneManager = airplanemanager;

            this.FlightDirector = flightdirector;
            this.SimulationProperties = simprops;
            this.AirplaneSpawner = spawner;
        }

        private void OnTimerTick(object o, EventArgs e)
        {
            
        }

        public void Init(ISimulationProperties simprops)
        {
            this.SimulationProperties = simprops;


            AirplaneManager.Reset();
        }

        public void Reset()
        {
            if(Running)
            {
                Stop();
            }

            this.SimulationProperties.Reset();
        }

        public void Start()
        {
            this.FlightDirector.Start();
        }

        public void Stop()
        {
            this.FlightDirector.Stop();
        }
    }
}
