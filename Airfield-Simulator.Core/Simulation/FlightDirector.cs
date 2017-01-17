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
    public class FlightDirector : SimulationObject, IFlightDirector
    {
        private ISimulationProperties simulationProperties;
        private IAirplaneManager airplaneManager;
        private IRouter router;

        private Dictionary<Aircraft, IRoute> AircraftRoutes { get; set; }



        public FlightDirector(IAirplaneManager airplanemanager, IRouter router, ISimulationProperties simprops)
        {
            this.airplaneManager = airplanemanager;
            this.router = router;
            this.simulationProperties = simprops;

            //FrameManager.AddUpdateObject(this);
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public override void AfterUpdate()
        {
            foreach(Aircraft a in airplaneManager.AircraftList)
            {

            }
        }

        private void IssueInstruction()
        {
            throw new NotImplementedException();
        }
    }
}
