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

        internal ITimer timer;


        public SimulationController(ITimer timer, IAirplaneManager airplanemanager, IFlightDirector flightdirector, IAirplaneSpawner spawner, ISimulationProperties simprops)
        {
            this.timer = timer;
            this.AirplaneManager = airplanemanager;
            this.FlightDirector = flightdirector;
            this.SimulationProperties = simprops;
            this.AirplaneSpawner = spawner;

            this.timer.Tick += OnTimerTick;
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
            timer.Start();
            Running = true;

            this.FlightDirector.Start();
            this.AirplaneSpawner.Start();
        }

        public void Stop()
        {
            timer.Stop();
            Running = false;

            this.FlightDirector.Stop();
            this.AirplaneSpawner.Stop();
        }
    }
}
