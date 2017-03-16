using NUnit.Framework;
using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Airfield_Simulator.Core.Models.Tests
{
    [TestFixture()]
    public class SimulationPropertiesTests
    {
        private SimulationProperties _simulationProperties;


        [SetUp]
        public void Init()
        {
            _simulationProperties = new SimulationProperties();
        }

        [Test]
        public void PropertyChangedTest()
        {
            PropertyInfo[] properties = typeof(SimulationProperties).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                bool eventraised = false;
                string eventPropertyName = null;
                _simulationProperties.PropertyChanged += (sender, e) => 
                {
                    eventraised = true;
                    eventPropertyName = e.PropertyName;
                };

                property.SetValue(_simulationProperties, null);

                Assert.IsTrue(eventraised);
                Assert.That(eventPropertyName, Is.EqualTo(property.Name));
            }
        }
    }
}