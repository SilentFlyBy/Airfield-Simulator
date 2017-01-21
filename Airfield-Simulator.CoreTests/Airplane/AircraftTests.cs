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
        Aircraft ac;


        [SetUp]
        public void Initialize()
        {
            ac = new Aircraft(new GeoPoint(5, 2), 0, new SimulationProperties() { SimulationSpeed = 2.8 });
            FrameDispatcher.DeltaTime = 1;
        }

        [Test]
        public void AircraftTest()
        {
            ac = new Aircraft(new GeoPoint(5, 2), 0, new SimulationProperties() { SimulationSpeed = 2.8 });

            Assert.IsTrue(ac.Position.X == 5 && ac.Position.Y == 2);
            Assert.IsTrue(ac.SimulationProperties.SimulationSpeed == 2.8);
        }

        [Test]
        public void TurnLeftTest()
        {
            ac.TurnLeft(270);
            Assert.That(ac.ActualHeading, Is.LessThan(360));
        }

        [Test]
        public void TurnRightTest()
        {
            ac.ActualHeading = 359;
            ac.TurnRight(90);
            Assert.That(ac.ActualHeading, Is.GreaterThan(0));
        }

        [Test]
        public void FlyTest()
        {
            //Heading 0
            ac.Position.X = 0;
            ac.Position.Y = 0;
            ac.ActualHeading = 0;

            ac.BeforeUpdate();

            Assert.That(ac.Position.X, Is.EqualTo(0));
            Assert.That(ac.Position.Y, Is.GreaterThan(0));


            //Heading 90
            ac.Position.X = 0;
            ac.Position.Y = 0;
            ac.ActualHeading = 90;

            ac.BeforeUpdate();

            Assert.That(ac.Position.X, Is.GreaterThan(0));
            Assert.That(ac.Position.Y, Is.EqualTo(0));


            //Heading 180
            ac.Position.X = 0;
            ac.Position.Y = 0;
            ac.ActualHeading = 180;

            ac.BeforeUpdate();

            Assert.That(ac.Position.X, Is.EqualTo(0));
            Assert.That(ac.Position.Y, Is.LessThan(0));


            //Heading 270
            ac.Position.X = 0;
            ac.Position.Y = 0;
            ac.ActualHeading = 270;

            ac.BeforeUpdate();

            Assert.That(ac.Position.X, Is.LessThan(0));
            Assert.That(ac.Position.Y, Is.EqualTo(0));
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