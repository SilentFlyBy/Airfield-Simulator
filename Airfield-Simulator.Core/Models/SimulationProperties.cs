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


        private double simulationSpeed;
        public double SimulationSpeed
        {
            get
            {
                return simulationSpeed;
            }
            set
            {
                simulationSpeed = value;
                NotifyPropertyChanged("SimulationSpeed");
            }
        }

        private int instructionsPerMinute;
        public int InstructionsPerMinute
        {
            get
            {
                return instructionsPerMinute;
            }

            set
            {
                instructionsPerMinute = value;
                NotifyPropertyChanged("InstructionsPerMinute");
            }
        }

        private int aircraftSpawnsPerSecond;
        public int AircraftSpawnsPerSecond
        {
            get
            {
                return aircraftSpawnsPerSecond;
            }

            set
            {
                aircraftSpawnsPerSecond = value;
                NotifyPropertyChanged("AircraftSpawnsPerSecond");
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        private void NotifyPropertyChanged(string prop)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
