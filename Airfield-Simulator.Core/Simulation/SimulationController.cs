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

        public bool Running { get; private set; }

        internal ITimer timer;

        private Random random;


        public SimulationController(ITimer timer, IAirplaneManager airplanemanager, IFlightDirector flightdirector, ISimulationProperties simprops)
        {
            this.timer = timer;
            this.AirplaneManager = airplanemanager;
            this.FlightDirector = flightdirector;
            this.SimulationProperties = simprops;
            this.random = new Random();

            this.timer.Tick += (o, args) =>
            {
                OnTimerTick();
            };
        }

        private void OnTimerTick()
        {
            if(GetRandomBoolean(1))
            {
                AirplaneManager.CreateAircraft(new GeoPoint(1000, 1000), 0);
            }
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
            AirplaneManager.CreateAircraft(new GeoPoint(0, 0), 90);
            AirplaneManager.CreateAircraft(new GeoPoint(1000, 0), 270);
            timer.Start();
            Running = true;
        }

        public void Stop()
        {
            timer.Stop();
            Running = false;
        }


        private bool GetRandomBoolean(int prapability)
        {
            int value = random.Next(0, 100);

            return value <= prapability;
        }
    }
}
