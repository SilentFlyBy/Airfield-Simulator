using Airfield_Simulator.Core.FlightRoutes;
using Airfield_Simulator.Core.Models;
using Airfield_Simulator.Core.Simulation;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.CoreTests.Simulation
{
    [TestFixture]
    public class FlightDirectorTest
    {
        private Mock<ISimulationProperties> simulationProperties;
        private Mock<IAirplaneManager> airplaneManager;
        private Mock<IRouter> router;


        [SetUp]
        public void Init()
        {
            this.simulationProperties = new Mock<ISimulationProperties>();
            this.airplaneManager = new Mock<IAirplaneManager>();
            this.router = new Mock<IRouter>();
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
    }
}
