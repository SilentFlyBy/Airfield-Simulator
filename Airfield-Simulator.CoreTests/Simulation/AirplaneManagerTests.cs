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
        Mock<ISimulationProperties> Simprops;


        [SetUp]
        public void Initialize()
        {
            Simprops = new Mock<ISimulationProperties>();

            ApManager = new AirplaneManager(Simprops.Object);
        }


        [Test]
        public void CreateAircraftTest()
        {
            Aircraft ac = ApManager.CreateAircraft(new GeoPoint(2, 3), 10);

            Assert.IsTrue(ac.Position.X == 2);
            Assert.IsTrue(ac.Position.Y == 3);
            Assert.That(ac.ActualHeading, Is.EqualTo(10));
            Assert.IsTrue(ApManager.AircraftList.Last() == ac);
        }

        [Test]
        public void RemoveAircraftTest()
        {
            Aircraft ac = ApManager.CreateAircraft(new GeoPoint(2, 3), 10);
            ApManager.AircraftList.Remove(ac);

            Assert.That(ApManager.AircraftList.Count, Is.EqualTo(0));
        }

        [Test]
        public void ResetTest()
        {
            Aircraft ac = ApManager.CreateAircraft(new GeoPoint(2, 3), 10);
            ApManager.Reset();

            Assert.IsTrue(ApManager.AircraftList.Count == 0);
        }

        [Test]
        public void AirplaneCollisionTest()
        {
            bool collisionEventFired = false;
            ApManager.Collision += (o, e) => { collisionEventFired = true; };

            //Collision

            ApManager.CreateAircraft(new GeoPoint(0, 0), 90);
            ApManager.CreateAircraft(new GeoPoint(40, 0), 270);

            ApManager.UpdateFrame();

            Assert.IsTrue(collisionEventFired);


            ApManager.Reset();
            collisionEventFired = false;


            //No collision

            ApManager.CreateAircraft(new GeoPoint(0, 0), 90);
            ApManager.CreateAircraft(new GeoPoint(201, 0), 270);

            ApManager.UpdateFrame();

            Assert.IsFalse(collisionEventFired);


        }
    }
}