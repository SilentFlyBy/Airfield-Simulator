using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airfield_Simulator.Core.Simulation
{
    public class SimulationTimer : ITimer, IDisposable
    {
        private Timer timer;

        public SimulationTimer()
        {
            timer = new Timer();
            timer.Tick += (o, args) =>
            {
                this.Tick(o, args);
            };
        }


        public int Interval
        {
            get
            {
                return timer.Interval;
            }

            set
            {
                timer.Interval = value;
            }
        }

        public event EventHandler Tick;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                timer.Dispose();
            }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
