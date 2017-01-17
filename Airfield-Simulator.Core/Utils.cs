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
    }
}
