using Airfield_Simulator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Airfield_Simulator.Core.Models;
using Airfield_Simulator.Core.Simulation;
using Airfield_Simulator.Core.Airplane;
using NUnit.Framework;

namespace Airfield_Simulator.Core.Tests.Simulation
{
    [TestFixture]
    public class AirplaneManagerTests
    {
        AirplaneManager ApManager;
        Mock<ITimer> Timer;
        Mock<ISimulationProperties> Simprops;


        [SetUp]
        public void Initialize()
        {
            Timer = new Mock<ITimer>();
            Simprops = new Mock<ISimulationProperties>();

            ApManager = new AirplaneManager(Timer.Object, Simprops.Object);
        }


        [Test]
        public void CreateAircraftTest()
        {
            Aircraft ac = ApManager.CreateAircraft(new GeoPoint(2, 3));

            Assert.IsTrue(ac.Position.Latitude == 2);
            Assert.IsTrue(ac.Position.Longitude == 3);
            Assert.IsTrue(ApManager.AircraftList.Last() == ac);
        }

        [Test]
        public void RemoveAircraftTest()
        {
            Aircraft ac = ApManager.CreateAircraft(new GeoPoint(2, 3));
            ApManager.AircraftList.Remove(ac);

            Assert.That(ApManager.AircraftList.Count, Is.EqualTo(0));
        }

        [Test]
        public void ResetTest()
        {
            Aircraft ac = ApManager.CreateAircraft(new GeoPoint(2, 3));
            ApManager.Reset();

            Assert.IsTrue(ApManager.AircraftList.Count == 0);
        }
    }
}