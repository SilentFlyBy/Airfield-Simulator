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
        private List<GeoPoint>  waypoints { get; set; }
        private int currentWaypointindex = 0;

        public Route()
        {
            this.waypoints = new List<GeoPoint>();
        }

        public GeoPoint this[int index]
        {
            get
            {
                return this.waypoints[index];
            }

            set
            {
                this.waypoints[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return this.waypoints.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public GeoPoint CurrentWaypoint
        {
            get
            {
                return this.waypoints[currentWaypointindex];
            }
        }

        public void Add(GeoPoint item)
        {
            this.waypoints.Add(item);
        }

        public void Clear()
        {
            this.waypoints.Clear();
        }

        public bool Contains(GeoPoint item)
        {
            return this.waypoints.Contains(item);
        }

        public void CopyTo(GeoPoint[] array, int arrayIndex)
        {
            this.waypoints.CopyTo(array, arrayIndex);
        }

        public IEnumerator<GeoPoint> GetEnumerator()
        {
            return this.waypoints.GetEnumerator();
        }

        public int IndexOf(GeoPoint item)
        {
            return this.waypoints.IndexOf(item);
        }

        public void Insert(int index, GeoPoint item)
        {
            this.waypoints.Insert(index, item);
        }

        public bool Remove(GeoPoint item)
        {
            return this.waypoints.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.waypoints.RemoveAt(index);
        }

        public void TargetNextWaypoint()
        {
            currentWaypointindex++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.waypoints.GetEnumerator();
        }
    }
}
