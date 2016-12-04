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
