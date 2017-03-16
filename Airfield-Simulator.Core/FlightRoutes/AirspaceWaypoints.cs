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
        private const int DownwindDistance = 2000;
        private const int FinalDistance = 4000;

        public static GeoPoint RunwayEndLeft { get; } = new GeoPoint(-750, 0);
        public static GeoPoint RunwayEndRight { get; } = new GeoPoint(750, 0);

        public static GeoPoint DownwindNorth { get; } = new GeoPoint(0, DownwindDistance);
        public static GeoPoint TurnPointNorth09 { get; } = new GeoPoint(-FinalDistance, DownwindDistance);
        public static GeoPoint TurnPointNorth27 { get; } = new GeoPoint(FinalDistance, DownwindDistance);
        public static GeoPoint DownwindSouth { get; } = new GeoPoint(0, -DownwindDistance);
        public static GeoPoint TurnPointSouth09 { get; } = new GeoPoint(-FinalDistance, -DownwindDistance);
        public static GeoPoint TurnPointSouth27 { get; } = new GeoPoint(FinalDistance, -DownwindDistance);

        public static GeoPoint Final27 { get; } = new GeoPoint(FinalDistance, 0);
        public static GeoPoint Final09 { get; } = new GeoPoint(-FinalDistance, 0);

        public static GeoPoint TouchDown27 { get; } = new GeoPoint(450, 0);
        public static GeoPoint TouchDown09 { get; } = new GeoPoint(450, 0);
    }
}
