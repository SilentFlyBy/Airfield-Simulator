using Airfield_Simulator.Core.Models;
using Airfield_Simulator.Core.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.FlightRoutes
{
    public class Router : IRouter
    {

        private readonly IWeatherController _weatherController;


        public Router(IWeatherController weathercontroller)
        {
            _weatherController = weathercontroller;
        }


        public IRoute GetRoute(RouteDestination destination, GeoPoint currentlocation)
        {
            return GetArrivalRoute(currentlocation);
        }


        private IRoute GetArrivalRoute(GeoPoint currentlocation)
        {
            return _weatherController.WindDegrees < 180 ? GetArrivalRoute09(currentlocation) : GetArrivalRoute27(currentlocation);
        }

        private static IRoute GetArrivalRoute27(GeoPoint currentlocation)
        {
            var returnroute = new Route();

            if(currentlocation.Y > 0)
            {
                returnroute.Add(AirspaceWaypoints.DownwindNorth);
                returnroute.Add(AirspaceWaypoints.TurnPointNorth27);
            }
            else
            {
                returnroute.Add(AirspaceWaypoints.DownwindSouth);
                returnroute.Add(AirspaceWaypoints.TurnPointSouth27);
            }

            returnroute.Add(AirspaceWaypoints.Final27);
            returnroute.Add(AirspaceWaypoints.TouchDown27);

            return returnroute;
        }

        private static IRoute GetArrivalRoute09(GeoPoint currentlocation)
        {
            var returnroute = new Route();

            if (currentlocation.Y > 0)
            {
                returnroute.Add(AirspaceWaypoints.DownwindNorth);
                returnroute.Add(AirspaceWaypoints.TurnPointNorth09);
            }
            else
            {
                returnroute.Add(AirspaceWaypoints.DownwindSouth);
                returnroute.Add(AirspaceWaypoints.TurnPointSouth09);
            }

            returnroute.Add(AirspaceWaypoints.Final09);
            returnroute.Add(AirspaceWaypoints.TouchDown09);

            return returnroute;
        }
    }
}
