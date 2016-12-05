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
        private static GeoPoint runwayEndLeft = new GeoPoint(-750, 0);
        public static GeoPoint RunwayEndLeft {
            get { return runwayEndLeft; }
        }

        private static GeoPoint runwayEndRight = new GeoPoint(750, 0);
        public static GeoPoint RunwayEndRight
        {
            get { return runwayEndRight; }
        }



        private static GeoPoint downwindNorth = new GeoPoint(0, 750);
        public static GeoPoint DownwindNorth
        {
            get { return downwindNorth; }
        }

        private static GeoPoint downwindSouth = new GeoPoint(0, -750);
        public static GeoPoint DownwindSouth
        {
            get { return downwindSouth; }
        }



        private static GeoPoint final27 = new GeoPoint(2250, 0);
        public static GeoPoint Final27
        {
            get { return final27; }
        }

        private static GeoPoint final09 = new GeoPoint(2250, 0);
        public static GeoPoint Final09
        {
            get { return final09; }
        }



        private static GeoPoint touchDown27 = new GeoPoint(450, 0);
        public static GeoPoint TouchDown27
        {
            get { return touchDown27; }
        }

        private static GeoPoint touchDown09 = new GeoPoint(450, 0);
        public static GeoPoint TouchDown09
        {
            get { return touchDown09; }
        }
    }
}
