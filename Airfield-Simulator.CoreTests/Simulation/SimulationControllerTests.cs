using Airfield_Simulator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Airfield_Simulator.Core.Simulation;
using Airfield_Simulator.Core.Models;
using NUnit.Framework;

namespace Airfield_Simulator.Core.Tests.Simulation
{
    [TestFixture]
    public class SimulationControllerTests
    {

        SimulationController SimController;
        Mock<IAirplaneManager> ApManager;
        Mock<IFlightDirector> FlightDirector;
        Mock<ISimulationProperties> SimProperties;
        Mock<IAirplaneSpawner> AirplaneSpawner;


        [SetUp]
        public void Initialize()
        {
            ApManager = new Mock<IAirplaneManager>();
            FlightDirector = new Mock<IFlightDirector>();
            AirplaneSpawner = new Mock<IAirplaneSpawner>();
            SimProperties = new Mock<ISimulationProperties>();

            SimController = new SimulationController(ApManager.Object, FlightDirector.Object, AirplaneSpawner.Object, SimProperties.Object);
        }


        [Test]
        public void InitTest()
        {
            ApManager.Setup(apm => apm.Reset()).Verifiable();
            SimController.Init(new SimulationProperties() { SimulationSpeed = 1 });

            Assert.IsTrue(SimController.SimulationProperties.SimulationSpeed == 1);
            ApManager.Verify();
        }

        [Test]
        public void ResetTest()
        {
            SimController.Reset();

            Assert.That(!SimController.Running);
        }

        [Test]
        public void StartTest()
        {
            SimController.Start();

            Assert.IsTrue(SimController.Running);
        }

        [Test]
        public void StopTest()
        {
            SimController.Stop();

            Assert.IsFalse(SimController.Running);
        }
    }
}