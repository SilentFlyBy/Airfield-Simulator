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
        private Dictionary<ArrivalRoute, IRoute> arrivalRoutes;
        private Dictionary<DepartureRoute, IRoute> departureRoutes;

        private IWeatherController weatherController;


        public Router(IWeatherController weathercontroller)
        {
            this.weatherController = weathercontroller;

            arrivalRoutes = new Dictionary<ArrivalRoute, IRoute>();
            departureRoutes = new Dictionary<DepartureRoute, IRoute>();

            Route november09 = new Route();
            november09.Add(new GeoPoint(1000, 5000));
            november09.Add(new GeoPoint(1000, 10000));
            november09.Add(new GeoPoint(1000, 20000));
            november09.Add(new GeoPoint(1000, 30000));

            arrivalRoutes.Add(ArrivalRoute.November_09, new Route());
            arrivalRoutes.Add(ArrivalRoute.Sierra_09, new Route());
        }


        public IRoute GetRoute(RouteDestination destination, GeoPoint currentlocation)
        {
            if(destination == RouteDestination.Arrival)
            {
                return GetArrivalRoute(currentlocation);
            }
            else if(destination == RouteDestination.Departure)
            {
                return GetDepartureRoute(currentlocation);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private IRoute GetDepartureRoute(GeoPoint currentlocation)
        {
            if(weatherController.WindDegrees <180)
            {
                return GetDepartureRoute09(currentlocation);
            }
            else
            {
                return GetDepartureRoute27(currentlocation);
            }
        }

        private IRoute GetDepartureRoute27(GeoPoint currentlocation)
        {
            throw new NotImplementedException();
        }

        private IRoute GetDepartureRoute09(GeoPoint currentlocation)
        {
            throw new NotImplementedException();
        }

        private IRoute GetArrivalRoute(GeoPoint currentlocation)
        {
            if (weatherController.WindDegrees < 180)
            {
                return GetArrivalRoute09(currentlocation);
            }
            else
            {
                return GetArrivalRoute27(currentlocation);
            }
        }

        private IRoute GetArrivalRoute27(GeoPoint currentlocation)
        {
            Route returnroute = new Route();

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

        private IRoute GetArrivalRoute09(GeoPoint currentlocation)
        {
            Route returnroute = new Route();

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
