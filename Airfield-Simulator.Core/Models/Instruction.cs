using Airfield_Simulator.Core.Airplane;
using Airfield_Simulator.Core.FlightRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Models
{
    public class Instruction
    {
        public TurnDirection TurnDirection { get; set; }
        public double? TargetHeading { get; set; }
        public IRoute Route;
        public int Priority { get; set; }
    }
}
