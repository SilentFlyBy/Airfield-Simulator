using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core
{
    public static class Utils
    {
        public static bool OutOfToleranceRange(double value1, double value2, double range)
        {
            return value1 >= value2 + range || value1 <= value2 - range;
        }

        public static double Map(double value, double range1Min, double range1Max, double range2Min, double range2Max)
        {
            if (value < range1Min) value = range1Min;
            if (value > range1Max) value = range1Max; 
            return (value - range1Min) / (range1Max - range1Min) * (range2Max - range2Min) + range2Min;
        }
    }
}
