﻿using Airfield_Simulator.Core.Models;
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
            Timer.SetupGet(t => t.Interval).Returns(1000);
            ac = new Aircraft(Timer.Object, new GeoPoint(5, 2), new SimulationProperties() { SimulationSpeed = 2.8 });
        }

        [Test]
        public void AircraftTest()
        {
            ac = new Aircraft(Timer.Object, new GeoPoint(5, 2), new SimulationProperties() { SimulationSpeed = 2.8 });

            Assert.IsTrue(ac.Position.X == 5 && ac.Position.Y == 2);
            Assert.IsTrue(ac.SimulationProperties.SimulationSpeed == 2.8);
        }

        [Test]
        public void TurnLeftTest()
        {
            ac.TurnLeft(270);
            Timer.Raise(t => t.Tick += null, this, EventArgs.Empty);
            Assert.That(ac.ActualHeading, Is.LessThan(360));
        }

        [Test]
        public void TurnRightTest()
        {
            ac.ActualHeading = 359;
            ac.TurnRight(90);
            Timer.Raise(t => t.Tick += null, this, EventArgs.Empty);
            Assert.That(ac.ActualHeading, Is.GreaterThan(0));
        }

        [Test]
        public void ChangeHeightTest()
        {
            Assert.Fail();
        }

        [Test]
        public void TakeOffTest()
        {
            Assert.Fail();
        }

        [Test]
        public void ClearToLandTest()
        {
            Assert.Fail();
        }

        [Test]
        public void AbortLandingTest()
        {
            Assert.Fail();
        }
    }
}