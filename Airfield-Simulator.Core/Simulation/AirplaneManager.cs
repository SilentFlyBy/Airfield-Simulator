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
        public List<Aircraft> AircraftList { get; private set; }
        public event CollisionEventHandler Collision;

        private ISimulationProperties SimulationProperties { get; set; }



        public AirplaneManager(ISimulationProperties simprops)
        {
            AircraftList = new List<Aircraft>();
            SimulationProperties = simprops;
        }


        public override void AfterUpdate()
        {
            CheckForCollision();
        }

        public Aircraft CreateAircraft(GeoPoint position, int heading)
        {
            var ac = new Aircraft(position, heading, SimulationProperties);
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
            Collision?.Invoke(sender, e);
        }

        private void CheckForCollision()
        {
            foreach (var ac in AircraftList.ToList())
            {
                foreach (var ac2 in AircraftList.ToList())
                {
                    if (ac == ac2) break;

                    var distance = GeoPoint.GetDistance(ac.Position, ac2.Position);

                    if (distance < 500)
                    {
                        OnCollision(ac, new CollisionEventArgs(ac2));
                    }
                }
            }
        }
    }
}
