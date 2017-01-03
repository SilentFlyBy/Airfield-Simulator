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

        [Test()]
        public void GetDistanceToTest()
        {
            GeoPoint point1 = new GeoPoint(2, 2);
            GeoPoint point2 = new GeoPoint(4, 5);

            double distance = GeoPoint.GetDistance(point1, point2);
            double distanceto = point1.GetDistanceTo(point2);

            Assert.That(distance, Is.EqualTo(distanceto));
        }

        [Test()]
        public void GetHeadingToTest()
        {
            GeoPoint point1 = new GeoPoint(2, 2);
            GeoPoint point2 = new GeoPoint(4, 5);

            double heading = GeoPoint.GetHeading(point1, point2);
            double headingto = point1.GetHeadingTo(point2);

            Assert.That(heading, Is.EqualTo(headingto));
        }

        [Test()]
        public void GetHeadingTest()
        {
            //Quadrant 1
            GeoPoint point1 = new GeoPoint(2, 2);
            GeoPoint point2 = new GeoPoint(4, 5);
            double heading = GeoPoint.GetHeading(point1, point2);

            Assert.That(heading, Is.LessThan(45));

            point2.Y = 4;
            point2.X = 5;
            heading = GeoPoint.GetHeading(point1, point2);

            Assert.That(heading, Is.GreaterThan(45));

            //Quadrant 2
            point2.X = 0;
            point2.Y = 5;
            heading = GeoPoint.GetHeading(point1, point2);

            Assert.That(heading, Is.GreaterThan(315));

            point2.Y = 4;
            point2.X = -1;
            heading = GeoPoint.GetHeading(point1, point2);

            Assert.That(heading, Is.LessThan(315));

            //Quadrant 3
            point2.Y = 0;
            heading = GeoPoint.GetHeading(point1, point2);

            Assert.That(heading, Is.GreaterThan(225));

            point2.X = 0;
            point2.Y = -1;

            heading = GeoPoint.GetHeading(point1, point2);

            Assert.That(heading, Is.LessThan(225));

            //Quadrant 4
            point2.X = 4;
            heading = GeoPoint.GetHeading(point1, point2);

            Assert.That(heading, Is.GreaterThan(135));

            point2.X = 5;
            point2.Y = 0;
            heading = GeoPoint.GetHeading(point1, point2);

            Assert.That(heading, Is.LessThan(135));
        }
    }
}