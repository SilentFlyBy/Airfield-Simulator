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
            throw new NotImplementedException();
        }
    }
}
