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

        public double GetDistanceTo(GeoPoint point)
        {
            return GetDistance(this, point);
        }

        public double GetHeadingTo(GeoPoint point)
        {
            return GetHeading(this, point);
        }

        public static double GetDistance(GeoPoint pointA, GeoPoint pointB)
        {
            return Math.Round(Math.Sqrt(Math.Pow((pointB.X - pointA.X), 2)+ Math.Pow((pointB.Y - pointA.Y), 2)), 1);
        }

        public static double GetHeading(GeoPoint pointA, GeoPoint pointB)
        {
            var a = pointA.X - pointB.X;
            var b = pointA.Y - pointB.Y;

            var c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            var q = Math.Pow(a, 2) / c;
            var p = c - q;
            var h = Math.Sqrt(p * q);
            var alpha = Math.Atan(h / p);

            var degrees = alpha * (360 / (2 * Math.PI));

            if (pointA.X < pointB.X && pointA.Y < pointB.Y)
                return degrees;

            else if (pointA.X > pointB.X && pointA.Y < pointB.Y)
                return 360 - degrees;

            else if (pointA.X > pointB.X && pointA.Y > pointB.Y)
                return 180 + degrees;

            else
                return 180 - degrees;
        }
    }
}
