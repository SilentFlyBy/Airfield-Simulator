using Airfield_Simulator.Core.FlightRoutes;
using Airfield_Simulator.Core.Models;
using Airfield_Simulator.Core.Simulation;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.CoreTests.Simulation
{
    [TestFixture]
    public class FlightDirectorTests
    {
        private FlightDirector flightDirector;
        private Mock<ISimulationProperties> simulationProperties;
        private Mock<IAirplaneManager> airplaneManager;
        private Mock<IRouter> router;


        [SetUp]
        public void Init()
        {
            this.simulationProperties = new Mock<ISimulationProperties>();
            this.airplaneManager = new Mock<IAirplaneManager>();
            this.router = new Mock<IRouter>();

            this.flightDirector = new FlightDirector(airplaneManager.Object, router.Object, simulationProperties.Object);
        }


        [Test]
        public void InitTest()
        {
            Assert.Fail();
        }

        [Test]
        public void StartTest()
        {
            Assert.Fail();
        }

        [Test]
        public void StopTest()
        {
            Assert.Fail();
        }

        [Test]
        public void SimulationPropertyChangedTest()
        {
            simulationProperties.SetupSet(m => m.InstructionsPerMinute = It.IsAny<int>()).Raises(e => e.PropertyChanged += null, this, new PropertyChangedEventArgs("InstructionsPerMinute"));
            simulationProperties.SetupGet(m => m.InstructionsPerMinute).Returns(5);
            simulationProperties.Object.InstructionsPerMinute = 5;
        }
    }
}
