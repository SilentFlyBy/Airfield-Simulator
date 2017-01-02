using NUnit.Framework;
using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Models.Tests
{
    [TestFixture()]
    public class GeoPointTests
    {
        [Test()]
        public void GetDistanceTest()
        {
            GeoPoint point1 = new GeoPoint(2, 4);
            GeoPoint point2 = new GeoPoint(26, 9);

            double distance = GeoPoint.GetDistance(point1, point2);
            Assert.That(distance, Is.EqualTo(24.5));
        }
    }
}