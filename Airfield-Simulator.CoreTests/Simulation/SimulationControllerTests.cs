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
        Mock<ITimer> Timer;
        Mock<IFlightDirector> FlightDirector;
        Mock<ISimulationProperties> SimProperties;


        [SetUp]
        public void Initialize()
        {
            ApManager = new Mock<IAirplaneManager>();
            Timer = new Mock<ITimer>();
            FlightDirector = new Mock<IFlightDirector>();
            SimProperties = new Mock<ISimulationProperties>();

            SimController = new SimulationController(Timer.Object, ApManager.Object, FlightDirector.Object, SimProperties.Object);
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
            Timer.Setup(t => t.Start()).Verifiable();
            SimController.Start();

            Assert.IsTrue(SimController.Running);
            Timer.Verify();
        }

        [Test]
        public void StopTest()
        {
            Timer.Setup(t => t.Stop()).Verifiable();
            SimController.Stop();

            Assert.IsFalse(SimController.Running);
            Timer.Verify();
        }
    }
}