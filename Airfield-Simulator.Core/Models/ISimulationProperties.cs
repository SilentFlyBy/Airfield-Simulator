using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Models
{
    public interface ISimulationProperties : INotifyPropertyChanged
    {
        double SimulationSpeed { get; set; }
        int InstructionsPerMinute { get; set; }
        int AircraftSpawnsPerSecond { get; set; }

        void Reset();
    }
}
