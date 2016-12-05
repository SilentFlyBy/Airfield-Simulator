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
            GeoPoint southWestLocation = new GeoPoint(-5000, -5000);
            GeoPoint southEastLocation = new GeoPoint(5000, -5000);
            GeoPoint northWestLocation = new GeoPoint(-5000, 5000);
            GeoPoint northEastLocation = new GeoPoint(5000, 5000);

            weatherController.SetupGet(m => m.WindDegrees).Returns(179);
            IRoute approachSouthWest09 = router.GetRoute(RouteDestination.Arrival, southWestLocation);
            Assert.That(approachSouthWest09, Contains.Item(AirspaceWaypoints.DownwindSouth));
            Assert.That(approachSouthWest09, Contains.Item(AirspaceWaypoints.Final09));
            Assert.That(approachSouthWest09, Contains.Item(AirspaceWaypoints.TouchDown09));

            IRoute approachSouthEast09 = router.GetRoute(RouteDestination.Arrival, southEastLocation);
            Assert.That(approachSouthEast09, Contains.Item(AirspaceWaypoints.DownwindSouth));
            Assert.That(approachSouthEast09, Contains.Item(AirspaceWaypoints.Final09));



            IRoute approachNorthWest09 = router.GetRoute(RouteDestination.Arrival, northWestLocation);
            Assert.That(approachNorthWest09, Contains.Item(AirspaceWaypoints.DownwindNorth));
            Assert.That(approachNorthWest09, Contains.Item(AirspaceWaypoints.Final09));
            Assert.That(approachSouthWest09, Contains.Item(AirspaceWaypoints.TouchDown09));

            IRoute approachNorthEast09 = router.GetRoute(RouteDestination.Arrival, northEastLocation);
            Assert.That(approachNorthEast09, Contains.Item(AirspaceWaypoints.DownwindNorth));
            Assert.That(approachNorthEast09, Contains.Item(AirspaceWaypoints.Final09));
            Assert.That(approachSouthWest09, Contains.Item(AirspaceWaypoints.TouchDown09));



            weatherController.SetupGet(m => m.WindDegrees).Returns(181);
            IRoute approachSouthWest27 = router.GetRoute(RouteDestination.Arrival, southWestLocation);
            Assert.That(approachSouthWest27, Contains.Item(AirspaceWaypoints.DownwindSouth));
            Assert.That(approachSouthWest27, Contains.Item(AirspaceWaypoints.Final27));
            Assert.That(approachSouthWest27, Contains.Item(AirspaceWaypoints.TouchDown27));

            IRoute approachSouthEast27 = router.GetRoute(RouteDestination.Arrival, southEastLocation);
            Assert.That(approachSouthEast27, Contains.Item(AirspaceWaypoints.DownwindSouth));
            Assert.That(approachSouthEast27, Contains.Item(AirspaceWaypoints.Final27));
            Assert.That(approachSouthWest27, Contains.Item(AirspaceWaypoints.TouchDown27));



            IRoute approachNorthWest27 = router.GetRoute(RouteDestination.Arrival, northWestLocation);
            Assert.That(approachNorthWest27, Contains.Item(AirspaceWaypoints.DownwindNorth));
            Assert.That(approachNorthWest27, Contains.Item(AirspaceWaypoints.Final27));
            Assert.That(approachSouthWest27, Contains.Item(AirspaceWaypoints.TouchDown27));

            IRoute approachNorthEast27 = router.GetRoute(RouteDestination.Arrival, northEastLocation);
            Assert.That(approachNorthEast27, Contains.Item(AirspaceWaypoints.DownwindNorth));
            Assert.That(approachNorthEast27, Contains.Item(AirspaceWaypoints.Final27));
            Assert.That(approachSouthWest27, Contains.Item(AirspaceWaypoints.TouchDown27));
        }
    }
}