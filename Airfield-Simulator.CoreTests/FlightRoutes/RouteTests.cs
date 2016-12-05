using Airfield_Simulator.Core.FlightRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airfield_Simulator.Core.Models;
using System.Collections;
using NUnit.Framework;

namespace Airfield_Simulator.Core.FlightRoutes.Tests
{
    [TestFixture]
    public class RouteTests
    {
        private Route route;
        GeoPoint testpoint;
        GeoPoint testpoint1;

        [SetUp]
        public void Initialize()
        {
            this.route = new Route();
            testpoint = new GeoPoint(1000, 1000);
            testpoint1 = new GeoPoint(2000, 2000);
        }

        [Test]
        public void AddTest()
        {
            route.Add(testpoint);

            if (route[0] == testpoint)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }

        }

        [Test]
        public void ClearTest()
        {
            route.Add(testpoint);
            if (route[0] == testpoint)
            {
                route.Clear();
                Assert.IsTrue(route.Count() == 0);
            }
            else
            {
                Assert.Fail();
            }

        }

        [Test]
        public void ContainsTest()
        {
            route.Add(testpoint);
            if (route[0] == testpoint)
            {
                Assert.IsTrue(route.Contains(testpoint));
            }

            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CopyToTest()
        {
            route.Add(testpoint);
            route.Add(testpoint);
            if (route[0] == testpoint)
            {
                GeoPoint[] array = new GeoPoint[5];
                route.CopyTo(array, 2);

                Assert.That(array[0], Is.Null);
                Assert.That(array[1], Is.Null);
                Assert.That(array[4], Is.Null);
                Assert.That(array[2].Y, Is.EqualTo(1000));
                Assert.That(array[3].Y, Is.EqualTo(1000));
            }

            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void GetEnumeratorTest()
        {
            route.Add(testpoint);
            route.Add(testpoint1);


            IEnumerator enm = route.GetEnumerator();
            Assert.That(enm, Is.Not.Null);
            enm.MoveNext();
            Assert.That(enm.Current, Is.EqualTo(testpoint));
            enm.MoveNext();
            Assert.That(enm.Current, Is.EqualTo(testpoint1));
            enm.Reset();
            Assert.Throws<InvalidOperationException>(delegate { object o = enm.Current; });
        }

        [Test]
        public void IndexOfTest()
        {
            route.Add(testpoint);
            route.Add(testpoint1);

            Assert.That(route.IndexOf(testpoint1), Is.EqualTo(1));
        }

        [Test]
        public void InsertTest()
        {
            route.Add(testpoint);
            route.Add(testpoint);
            route.Add(testpoint);
            route.Add(testpoint);
            route.Add(testpoint);

            route.Insert(3, testpoint1);

            Assert.IsTrue(route[3] == testpoint1);
        }

        [Test]
        public void RemoveTest()
        {
            route.Add(testpoint);
            if (route[0] == testpoint)
            {
                route.Remove(testpoint);
                Assert.That(route.Count, Is.EqualTo(0));
            }

            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void RemoveAtTest()
        {
            route.Add(testpoint1);
            route.Add(testpoint1);
            route.Add(testpoint1);
            route.Add(testpoint1);
            route.Add(testpoint1);


            route.RemoveAt(3);
            Assert.That(route.Count, Is.EqualTo(4));      
        }

        [Test]
        public void TargetNextWaypointTest()
        {
            route.Add(testpoint);
            route.Add(testpoint1);
            route.TargetNextWaypoint();

            Assert.That(route.CurrentWaypoint, Is.EqualTo(testpoint1));
        }
    }
}