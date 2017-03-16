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
        Aircraft _ac;


        [SetUp]
        public void Initialize()
        {
            _ac = new Aircraft(new GeoPoint(5, 2), 0, new SimulationProperties() { SimulationSpeed = 2.8 });
            FrameDispatcher.DeltaTime = 1;
        }

        [Test]
        public void AircraftTest()
        {
            _ac = new Aircraft(new GeoPoint(5, 2), 0, new SimulationProperties() { SimulationSpeed = 2.8 });

            Assert.IsTrue(_ac.Position.X == 5 && _ac.Position.Y == 2);
            Assert.IsTrue(_ac.SimulationProperties.SimulationSpeed == 2.8);
        }

        [Test]
        public void TurnLeftTest()
        {
            _ac.TurnLeft(270);
            Assert.That(_ac.ActualHeading, Is.LessThan(360));
        }

        [Test]
        public void TurnRightTest()
        {
            _ac.ActualHeading = 359;
            _ac.TurnRight(90);
            Assert.That(_ac.ActualHeading, Is.GreaterThan(0));
        }

        [Test]
        public void FlyTest()
        {
            //Heading 0
            _ac.Position.X = 0;
            _ac.Position.Y = 0;
            _ac.ActualHeading = 0;

            _ac.BeforeUpdate();

            Assert.That(_ac.Position.X, Is.EqualTo(0));
            Assert.That(_ac.Position.Y, Is.GreaterThan(0));


            //Heading 90
            _ac.Position.X = 0;
            _ac.Position.Y = 0;
            _ac.ActualHeading = 90;

            _ac.BeforeUpdate();

            Assert.That(_ac.Position.X, Is.GreaterThan(0));
            Assert.That(_ac.Position.Y, Is.EqualTo(0));


            //Heading 180
            _ac.Position.X = 0;
            _ac.Position.Y = 0;
            _ac.ActualHeading = 180;

            _ac.BeforeUpdate();

            Assert.That(_ac.Position.X, Is.EqualTo(0));
            Assert.That(_ac.Position.Y, Is.LessThan(0));


            //Heading 270
            _ac.Position.X = 0;
            _ac.Position.Y = 0;
            _ac.ActualHeading = 270;

            _ac.BeforeUpdate();

            Assert.That(_ac.Position.X, Is.LessThan(0));
            Assert.That(_ac.Position.Y, Is.EqualTo(0));
        }
    }
}