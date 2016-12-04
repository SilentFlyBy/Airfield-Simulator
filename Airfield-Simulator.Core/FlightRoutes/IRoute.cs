using Airfield_Simulator.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.FlightRoutes
{
    public interface IRoute : IList<GeoPoint>
    {
        GeoPoint CurrentWaypoint { get; }
        void TargetNextWaypoint();
    }
}
