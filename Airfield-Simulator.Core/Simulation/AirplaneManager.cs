using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Airfield_Simulator.Core.Airplane;

namespace Airfield_Simulator.Core.Simulation
{
    public class AirplaneManager : IAirplaneManager
    {
        public ISimulationProperties SimulationProperties { get; set; }
        public List<Aircraft> AircraftList { get; private set; }

        public event CollisionEventHandler Collision;

        private ITimer timer { get; set; }


        public AirplaneManager(ITimer t, ISimulationProperties simprops)
        {
            this.timer = t;
            this.AircraftList = new List<Aircraft>();
            this.SimulationProperties = simprops;
        }


        public Aircraft CreateAircraft(GeoPoint position)
        {
            Aircraft ac = new Aircraft(timer, position, SimulationProperties);

            AircraftList.Add(ac);
            return ac;
        }

        public void RemoveAircraft(Aircraft aircaft)
        {
            AircraftList.Remove(aircaft);
        }

        public void Reset()
        {
            AircraftList.Clear();
        }

        private void OnCollision(object sender, CollisionEventArgs e)
        {
            if(this.Collision != null)
            {
                Collision(sender, e);
            }
        }
    }
}
