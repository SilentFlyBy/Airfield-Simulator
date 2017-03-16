using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core.Models
{
    public class SimulationProperties : ISimulationProperties
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private double _simulationSpeed;
        public double SimulationSpeed
        {
            get
            {
                return _simulationSpeed;
            }
            set
            {
                _simulationSpeed = value;
                NotifyPropertyChanged("SimulationSpeed");
            }
        }

        private int _instructionsPerMinute;
        public int InstructionsPerMinute
        {
            get
            {
                return _instructionsPerMinute;
            }

            set
            {
                _instructionsPerMinute = value;
                NotifyPropertyChanged("InstructionsPerMinute");
            }
        }

        private int _aircraftSpawnsPerMinute;
        public int AircraftSpawnsPerMinute
        {
            get
            {
                return _aircraftSpawnsPerMinute;
            }

            set
            {
                _aircraftSpawnsPerMinute = value;
                NotifyPropertyChanged("AircraftSpawnsPerMinute");
            }
        }

        private int _aircraftSpeed;
        public int AircraftSpeed
        {
            get
            {
                return _aircraftSpeed;
            }

            set
            {
                _aircraftSpeed = value;
                NotifyPropertyChanged("AircraftSpeed");
            }
        }

        private void NotifyPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
