using Airfield_Simulator.Core.Airplane;
using Airfield_Simulator.Core.FlightRoutes;
using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public class FlightDirector : IFlightDirector
    {
        public int InstructionsPerMinute { get; private set; }


        private ISimulationProperties simulationProperties;
        private IAirplaneManager airplaneManager;
        private IRouter router;

        private Dictionary<Aircraft, IRoute> AircraftRoutes { get; set; }



        public FlightDirector(IAirplaneManager airplanemanager, IRouter router, ISimulationProperties simprops)
        {
            this.airplaneManager = airplanemanager;
            this.router = router;
            this.simulationProperties = simprops;

            this.simulationProperties.PropertyChanged += UpdateInstructionsPerMinute;
        }


        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }


        private void UpdateInstructionsPerMinute(object sender, PropertyChangedEventArgs e)
        {
            InstructionsPerMinute = simulationProperties.InstructionsPerMinute;
        }
    }
}
