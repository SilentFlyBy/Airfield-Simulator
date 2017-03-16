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
        AirplaneManager _apManager;
        Mock<ISimulationProperties> _simprops;


        [SetUp]
        public void Initialize()
        {
            _simprops = new Mock<ISimulationProperties>();
            _apManager = new AirplaneManager(_simprops.Object);
        }


        [Test]
        public void CreateAircraftTest()
        {
            Aircraft ac = _apManager.CreateAircraft(new GeoPoint(2, 3), 10);

            Assert.IsTrue(ac.Position.X == 2);
            Assert.IsTrue(ac.Position.Y == 3);
            Assert.That(ac.ActualHeading, Is.EqualTo(10));
            Assert.IsTrue(_apManager.AircraftList.Last() == ac);
        }

        [Test]
        public void RemoveAircraftTest()
        {
            Aircraft ac = _apManager.CreateAircraft(new GeoPoint(2, 3), 10);
            _apManager.AircraftList.Remove(ac);

            Assert.That(_apManager.AircraftList.Count, Is.EqualTo(0));
        }

        [Test]
        public void ResetTest()
        {
            Aircraft ac = _apManager.CreateAircraft(new GeoPoint(2, 3), 10);
            _apManager.Reset();

            Assert.IsTrue(_apManager.AircraftList.Count == 0);
        }

        [Test]
        public void AirplaneCollisionTest()
        {
            bool collisionEventFired = false;
            _apManager.Collision += (o, e) => { collisionEventFired = true; };

            //Collision

            _apManager.CreateAircraft(new GeoPoint(0, 0), 90);
            _apManager.CreateAircraft(new GeoPoint(40, 0), 270);

            _apManager.AfterUpdate();

            Assert.IsTrue(collisionEventFired);


            _apManager.Reset();
            collisionEventFired = false;


            //No collision

            _apManager.CreateAircraft(new GeoPoint(0, 0), 90);
            _apManager.CreateAircraft(new GeoPoint(201, 0), 270);

            _apManager.BeforeUpdate();

            Assert.IsFalse(collisionEventFired);


        }
    }
}