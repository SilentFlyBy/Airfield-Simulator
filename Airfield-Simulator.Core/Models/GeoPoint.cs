using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Models
{
    public class GeoPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoPoint(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }

        public static double GetDistance(GeoPoint point_a, GeoPoint point_b)
        {
            throw new NotImplementedException();
        }
    }
}
