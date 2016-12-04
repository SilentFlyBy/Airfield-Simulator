using Airfield_Simulator.Core.Airplane;
using Airfield_Simulator.Core.FlightRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public class FlightDirector : IFlightDirector
    {
        private IAirplaneManager airplaneManager;
        private IRouter router;

        private Dictionary<Aircraft, IRoute> AircraftRoutes { get; set; }


        public FlightDirector(IAirplaneManager airplanemanager, IRouter router)
        {
            this.airplaneManager = airplanemanager;
            this.router = router;
        }


        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            foreach(Aircraft ac in airplaneManager.AircraftList)
            {

            }

            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
