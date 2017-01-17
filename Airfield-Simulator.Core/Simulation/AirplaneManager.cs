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
    public class AirplaneManager : SimulationObject, IAirplaneManager
    {
        public ISimulationProperties SimulationProperties { get; set; }
        public List<Aircraft> AircraftList { get; private set; }

        public event CollisionEventHandler Collision;


        public AirplaneManager(ISimulationProperties simprops)
        {
            this.AircraftList = new List<Aircraft>();
            this.SimulationProperties = simprops;
        }


        public override void AfterUpdate()
        {
            CheckForCollision();
        }

        public Aircraft CreateAircraft(GeoPoint position, int heading)
        {
            Aircraft ac = new Aircraft(position, heading,  SimulationProperties);

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

        private void CheckForCollision()
        {
            foreach (Aircraft ac in AircraftList.ToList())
            {
                foreach (Aircraft ac2 in AircraftList.ToList())
                {
                    if (ac == ac2) break;

                    double distance = GeoPoint.GetDistance(ac.Position, ac2.Position);

                    if (distance < 200)
                    {
                        OnCollision(ac, new CollisionEventArgs(ac2));
                    }
                }
            }
        }
    }
}
