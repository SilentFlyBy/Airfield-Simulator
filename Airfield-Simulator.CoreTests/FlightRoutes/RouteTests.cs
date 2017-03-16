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
        private Route _route;
        GeoPoint _testpoint;
        GeoPoint _testpoint1;

        [SetUp]
        public void Initialize()
        {
            _route = new Route();
            _testpoint = new GeoPoint(1000, 1000);
            _testpoint1 = new GeoPoint(2000, 2000);
        }

        [Test]
        public void AddTest()
        {
            _route.Add(_testpoint);

            if (_route[0] == _testpoint)
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
            _route.Add(_testpoint);
            if (_route[0] == _testpoint)
            {
                _route.Clear();
                Assert.IsTrue(_route.Count() == 0);
            }
            else
            {
                Assert.Fail();
            }

        }

        [Test]
        public void ContainsTest()
        {
            _route.Add(_testpoint);
            if (_route[0] == _testpoint)
            {
                Assert.IsTrue(_route.Contains(_testpoint));
            }

            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CopyToTest()
        {
            _route.Add(_testpoint);
            _route.Add(_testpoint);
            if (_route[0] == _testpoint)
            {
                GeoPoint[] array = new GeoPoint[5];
                _route.CopyTo(array, 2);

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
            _route.Add(_testpoint);
            _route.Add(_testpoint1);


            IEnumerator enm = _route.GetEnumerator();
            Assert.That(enm, Is.Not.Null);
            enm.MoveNext();
            Assert.That(enm.Current, Is.EqualTo(_testpoint));
            enm.MoveNext();
            Assert.That(enm.Current, Is.EqualTo(_testpoint1));
            enm.Reset();
            Assert.Throws<InvalidOperationException>(delegate { object o = enm.Current; });
        }

        [Test]
        public void IndexOfTest()
        {
            _route.Add(_testpoint);
            _route.Add(_testpoint1);

            Assert.That(_route.IndexOf(_testpoint1), Is.EqualTo(1));
        }

        [Test]
        public void InsertTest()
        {
            _route.Add(_testpoint);
            _route.Add(_testpoint);
            _route.Add(_testpoint);
            _route.Add(_testpoint);
            _route.Add(_testpoint);

            _route.Insert(3, _testpoint1);

            Assert.IsTrue(_route[3] == _testpoint1);
        }

        [Test]
        public void RemoveTest()
        {
            _route.Add(_testpoint);
            if (_route[0] == _testpoint)
            {
                _route.Remove(_testpoint);
                Assert.That(_route.Count, Is.EqualTo(0));
            }

            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void RemoveAtTest()
        {
            _route.Add(_testpoint1);
            _route.Add(_testpoint1);
            _route.Add(_testpoint1);
            _route.Add(_testpoint1);
            _route.Add(_testpoint1);


            _route.RemoveAt(3);
            Assert.That(_route.Count, Is.EqualTo(4));      
        }

        [Test]
        public void TargetNextWaypointTest()
        {
            _route.Add(_testpoint);
            _route.Add(_testpoint1);
            _route.TargetNextWaypoint();

            Assert.That(_route.CurrentWaypoint, Is.EqualTo(_testpoint1));
        }
    }
}