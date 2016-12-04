using Airfield_Simulator.Core.FlightRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airfield_Simulator.Core.Models;
using Moq;
using Airfield_Simulator.Core.Simulation;
using NUnit.Framework;

namespace Airfield_Simulator.Core.FlightRoutes.Tests
{
    [TestFixture]
    public class RouterTests
    {
        private Router router;
        Mock<IWeatherController> weatherController;


        [SetUp]
        public void Init()
        {
            this.weatherController = new Mock<IWeatherController>();
            this.router = new Router(weatherController.Object);
        }

        [Test]
        public void GetRouteTest()
        {
            GeoPoint southWestLocation = new GeoPoint(0, 0);
            GeoPoint southEastLocation = new GeoPoint(1200, 0);
            GeoPoint northWestLocation = new GeoPoint(0, 1000);
            GeoPoint northEastLocation = new GeoPoint(1200, 1000);

            weatherController.SetupProperty(m => m.WindDegrees, 179);
            IRoute approachSouthWest09 = router.GetRoute(RouteDestination.Arrival, southWestLocation);
            IRoute approachSouthEast09 = router.GetRoute(RouteDestination.Arrival, southEastLocation);
            IRoute approachNorthWest09 = router.GetRoute(RouteDestination.Arrival, northWestLocation);
            IRoute approachNorthEast09 = router.GetRoute(RouteDestination.Arrival, northEastLocation);

            weatherController.SetupProperty(m => m.WindDegrees, 181);
            IRoute approachSouthWest27 = router.GetRoute(RouteDestination.Arrival, southWestLocation);
            IRoute approachSouthEast27 = router.GetRoute(RouteDestination.Arrival, southEastLocation);
            IRoute approachNorthWest27 = router.GetRoute(RouteDestination.Arrival, northWestLocation);
            IRoute approachNorthEast27 = router.GetRoute(RouteDestination.Arrival, northEastLocation);
            Assert.Fail();
        }
    }
}