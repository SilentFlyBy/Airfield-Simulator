using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Models
{
    public class GeoPoint
    {
        public double X { get; set; }
        public double Y { get; set; }


        public GeoPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static double GetDistance(GeoPoint point_a, GeoPoint point_b)
        {
            throw new NotImplementedException();
        }
    }
}
