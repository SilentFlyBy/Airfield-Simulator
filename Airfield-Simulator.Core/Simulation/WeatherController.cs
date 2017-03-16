using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Airfield_Simulator.Core.Extensions;

namespace Airfield_Simulator.Core.Simulation
{
    public class WeatherController : SimulationObject, IWeatherController
    {
        private int _windDegrees;

        public int WindDegrees
        {
            get { return _windDegrees; }
            private set
            {
                if (value < 0)
                {
                    _windDegrees = 360 + value;
                }
                else if (value > 360)
                {
                    _windDegrees = 360 - value;
                }
                else
                {
                    _windDegrees = value;
                }
            }
        }

        private readonly Random _random;

        public WeatherController()
        {
            _random = new Random();
        }

        public override void BeforeUpdate()
        {
            var r = _random.NextGaussian();
            WindDegrees += (int)(r);
        }
    }
}
