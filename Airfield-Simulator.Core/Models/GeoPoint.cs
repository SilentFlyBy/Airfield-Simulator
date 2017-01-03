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

        public static double GetDistance(GeoPoint point_a, GeoPoint point_b)
        {
            return Math.Round(Math.Sqrt(Math.Pow((point_b.X - point_a.X), 2)+ Math.Pow((point_b.Y - point_a.Y), 2)), 1);
        }

        public static double GetHeading(GeoPoint point_a, GeoPoint point_b)
        {
            double a = point_a.X - point_b.X;
            double b = point_a.Y - point_b.Y;

            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            double q = Math.Pow(a, 2) / c;
            double p = c - q;
            double h = Math.Sqrt(p * q);
            double alpha = Math.Atan(h / p);

            double degrees = alpha * (360 / (2 * Math.PI));

            if (point_a.X < point_b.X && point_a.Y < point_b.Y)
                return degrees;

            else if (point_a.X > point_b.X && point_a.Y < point_b.Y)
                return 360 - degrees;

            else if (point_a.X > point_b.X && point_a.Y > point_b.Y)
                return 180 + degrees;

            else
                return 180 - degrees;
        }
    }
}
