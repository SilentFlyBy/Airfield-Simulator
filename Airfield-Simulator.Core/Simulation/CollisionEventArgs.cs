using Airfield_Simulator.Core.Airplane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Simulation
{
    public class CollisionEventArgs : EventArgs
    {
        public Aircraft CollidedAircraft { get; set; }

        public CollisionEventArgs(Aircraft collidedaircraft)
        {
            this.CollidedAircraft = collidedaircraft;
        }
    }
}
