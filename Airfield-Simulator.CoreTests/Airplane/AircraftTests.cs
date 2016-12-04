using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Airfield_Simulator.Core.Simulation;
using Airfield_Simulator.Core.Airplane;
using NUnit.Framework;

namespace Airfield_Simulator.Core.Airplane.Tests
{
    [TestFixture]
    public class AircraftTests
    {
        Mock<ITimer> Timer;
        Aircraft ac;


        [SetUp]
        public void Initialize()
        {
            Timer = new Mock<ITimer>();
            ac = new Aircraft(Timer.Object, new GeoPoint(5, 2), new SimulationProperties() { SimulationSpeed = 2.8 });
        }

        [Test]
        public void AircraftTest()
        {
            ac = new Aircraft(Timer.Object, new GeoPoint(5, 2), new SimulationProperties() { SimulationSpeed = 2.8 });

            Assert.IsTrue(ac.Position.Latitude == 5 && ac.Position.Longitude == 2);
            Assert.IsTrue(ac.SimulationProperties.SimulationSpeed == 2.8);
        }

        [Test]
        public void TurnLeftTest()
        {
            ac.TurnLeft(210);
        }

        [Test]
        public void TurnRightTest()
        {
            ac.TurnRight(210);
        }

        [Test]
        public void ChangeHeightTest()
        {
            ac.ChangeHeight(2000);
        }

        [Test]
        public void TakeOffTest()
        {
            ac.TakeOff();
        }

        [Test]
        public void ClearToLandTest()
        {
            ac.ClearToLand();
        }

        [Test]
        public void AbortLandingTest()
        {
            ac.AbortLanding();
        }
    }
}