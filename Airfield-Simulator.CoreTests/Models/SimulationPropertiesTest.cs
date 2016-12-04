using Airfield_Simulator.Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.CoreTests.Models
{
    [TestFixture]
    class SimulationPropertiesTest
    {
        private SimulationProperties simulationProperties;


        [SetUp]
        public void Initialize()
        {
            this.simulationProperties = new SimulationProperties();
        }

        [Test]
        public void ResetTest()
        {
            simulationProperties.Reset();
            Assert.Fail();
        }
    }
}
