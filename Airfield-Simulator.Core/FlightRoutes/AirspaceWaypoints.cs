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
        private const int DOWNWIND_DISTANCE = 2000;
        private const int FINAL_DISTANCE = 4000;

        private static GeoPoint runwayEndLeft = new GeoPoint(-750, 0);
        public static GeoPoint RunwayEndLeft {
            get { return runwayEndLeft; }
        }

        private static GeoPoint runwayEndRight = new GeoPoint(750, 0);
        public static GeoPoint RunwayEndRight
        {
            get { return runwayEndRight; }
        }



        private static GeoPoint downwindNorth = new GeoPoint(0, DOWNWIND_DISTANCE);
        public static GeoPoint DownwindNorth
        {
            get { return downwindNorth; }
        }

        private static GeoPoint turnPointNorth09 = new GeoPoint(-FINAL_DISTANCE, DOWNWIND_DISTANCE);
        public static GeoPoint TurnPointNorth09
        {
            get
            {
                return turnPointNorth09;
            }
        }

        private static GeoPoint turnPointNorth27 = new GeoPoint(FINAL_DISTANCE, DOWNWIND_DISTANCE);
        public static GeoPoint TurnPointNorth27
        {
            get
            {
                return turnPointNorth27;
            }
        }

        private static GeoPoint downwindSouth = new GeoPoint(0, -DOWNWIND_DISTANCE);
        public static GeoPoint DownwindSouth
        {
            get { return downwindSouth; }
        }

        private static GeoPoint turnPointSouth09 = new GeoPoint(-FINAL_DISTANCE, -DOWNWIND_DISTANCE);
        public static GeoPoint TurnPointSouth09
        {
            get
            {
                return turnPointSouth09;
            }
        }

        private static GeoPoint turnPointSouth27 = new GeoPoint(FINAL_DISTANCE, -DOWNWIND_DISTANCE);
        public static GeoPoint TurnPointSouth27
        {
            get
            {
                return turnPointSouth27;
            }
        }



        private static GeoPoint final27 = new GeoPoint(FINAL_DISTANCE, 0);
        public static GeoPoint Final27
        {
            get { return final27; }
        }

        private static GeoPoint final09 = new GeoPoint(-FINAL_DISTANCE, 0);
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
