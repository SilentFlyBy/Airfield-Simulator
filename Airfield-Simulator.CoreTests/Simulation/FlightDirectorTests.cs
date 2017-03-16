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
        private FlightDirector _flightDirector;
        private Mock<ISimulationProperties> _simulationProperties;
        private Mock<IAirplaneManager> _airplaneManager;
        private Mock<IRouter> _router;


        [SetUp]
        public void Init()
        {
            _simulationProperties = new Mock<ISimulationProperties>();
            _airplaneManager = new Mock<IAirplaneManager>();
            _router = new Mock<IRouter>();

            _flightDirector = new FlightDirector(_airplaneManager.Object, _router.Object, _simulationProperties.Object);
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
            _simulationProperties.SetupSet(m => m.InstructionsPerMinute = It.IsAny<int>()).Raises(e => e.PropertyChanged += null, this, new PropertyChangedEventArgs("InstructionsPerMinute"));
            _simulationProperties.SetupGet(m => m.InstructionsPerMinute).Returns(5);
            _simulationProperties.Object.InstructionsPerMinute = 5;
        }
    }
}
