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

        SimulationController _simController;
        Mock<IAirplaneManager> _apManager;
        Mock<IFlightDirector> _flightDirector;
        Mock<ISimulationProperties> _simProperties;
        Mock<IAirplaneSpawner> _airplaneSpawner;


        [SetUp]
        public void Initialize()
        {
            _apManager = new Mock<IAirplaneManager>();
            _flightDirector = new Mock<IFlightDirector>();
            _airplaneSpawner = new Mock<IAirplaneSpawner>();
            _simProperties = new Mock<ISimulationProperties>();

            _simController = new SimulationController(_apManager.Object, _flightDirector.Object, _airplaneSpawner.Object, _simProperties.Object);
        }


        [Test]
        public void InitTest()
        {
            _apManager.Setup(apm => apm.Reset()).Verifiable();
            _simController.Init(new SimulationProperties() { SimulationSpeed = 1 });

            Assert.IsTrue(_simController.SimulationProperties.SimulationSpeed == 1);
            _apManager.Verify();
        }

        [Test]
        public void ResetTest()
        {
            _simController.Reset();

            Assert.That(!_simController.Running);
        }
    }
}