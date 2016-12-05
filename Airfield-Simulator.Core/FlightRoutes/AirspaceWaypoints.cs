using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.FlightRoutes
{
    public static class AirspaceWaypoints
    {
        public static GeoPoint RunwayEndLeft {
            get { return new GeoPoint(-750, 0); }
        }
        public static GeoPoint RunwayEndRight
        {
            get { return new GeoPoint(750, 0); }
        }



        public static GeoPoint DownwindNorth
        {
            get { return new GeoPoint(0, 750); }
        }
        public static GeoPoint DownwindSouth
        {
            get { return new GeoPoint(0, -750); }
        }



        public static GeoPoint Final27
        {
            get { return new GeoPoint(2250, 0); }
        }
        public static GeoPoint Final09
        {
            get { return new GeoPoint(-2250, 0); }
        }



        public static GeoPoint Final27Long
        {
            get { return new GeoPoint(3250, 0); }
        }
        public static GeoPoint Final09Long
        {
            get { return new GeoPoint(-3250, 0); }
        }



        public static GeoPoint TouchDown27
        {
            get { return new GeoPoint(450, 0); }
        }
        public static GeoPoint TouchDown09
        {
            get { return new GeoPoint(-450, 0); }
        }
    }
}
