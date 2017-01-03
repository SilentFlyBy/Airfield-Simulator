using Airfield_Simulator.Core.Airplane;
using Airfield_Simulator.Core.FlightRoutes;
using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Airfield_Simulator.Core.Simulation
{
    public class FlightDirector : IFlightDirector
    {
        private int instructionsPerMinute;
        public int InstructionsPerMinute
        {
            get
            {
                return instructionsPerMinute;
            }
            private set
            {
                instructionsPerMinute = value;
                this.timer.Interval = 60 / value * 1000;
            }
        }


        private ISimulationProperties simulationProperties;
        private IAirplaneManager airplaneManager;
        private IRouter router;
        private Timer timer;

        private Dictionary<Aircraft, IRoute> AircraftRoutes { get; set; }



        public FlightDirector(IAirplaneManager airplanemanager, IRouter router, ISimulationProperties simprops)
        {
            this.airplaneManager = airplanemanager;
            this.router = router;
            this.simulationProperties = simprops;

            this.timer = new Timer();
            this.timer.Elapsed += OnTimerTick;
            this.simulationProperties.PropertyChanged += UpdateSimulationProperty;
        }

        private void OnTimerTick(object o, ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }


        private void UpdateSimulationProperty(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "InstructionsPerMinute")
                InstructionsPerMinute = simulationProperties.InstructionsPerMinute;
        }
    }
}
