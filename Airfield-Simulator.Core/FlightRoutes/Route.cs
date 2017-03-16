using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airfield_Simulator.Core.Models;

namespace Airfield_Simulator.Core.FlightRoutes
{
    public class Route : IRoute
    {
        private List<GeoPoint>  Waypoints { get; }
        private int _currentWaypointindex;

        public Route()
        {
            Waypoints = new List<GeoPoint>();
        }

        public GeoPoint this[int index]
        {
            get
            {
                return Waypoints[index];
            }

            set
            {
                Waypoints[index] = value;
            }
        }

        public int Count => Waypoints.Count;

        public bool IsReadOnly => true;

        public GeoPoint CurrentWaypoint => Waypoints[_currentWaypointindex];

        public void Add(GeoPoint item)
        {
            Waypoints.Add(item);
        }

        public void Clear()
        {
            Waypoints.Clear();
        }

        public bool Contains(GeoPoint item)
        {
            return Waypoints.Contains(item);
        }

        public void CopyTo(GeoPoint[] array, int arrayIndex)
        {
            Waypoints.CopyTo(array, arrayIndex);
        }

        public IEnumerator<GeoPoint> GetEnumerator()
        {
            return Waypoints.GetEnumerator();
        }

        public int IndexOf(GeoPoint item)
        {
            return Waypoints.IndexOf(item);
        }

        public void Insert(int index, GeoPoint item)
        {
            Waypoints.Insert(index, item);
        }

        public bool Remove(GeoPoint item)
        {
            return Waypoints.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Waypoints.RemoveAt(index);
        }

        public void TargetNextWaypoint()
        {
            _currentWaypointindex++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Waypoints.GetEnumerator();
        }
    }
}
