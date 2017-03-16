using Airfield_Simulator.Core.Airplane;
using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Airfield_Simulator.Core.Extensions;

namespace Airfield_Simulator.Core.Simulation
{
    public class AirplaneSpawner : SimulationObject, IAirplaneSpawner
    {
        public event AirplaneSpawnEventHandler AirplaneSpawn;

        private const int SpawnHorizon = 5500;

        private readonly ISimulationProperties _simulationProperties;
        private readonly IAirplaneManager _airplaneManager;
        private readonly Random _random;
        private double _elapsedSeconds;

        public AirplaneSpawner(ISimulationProperties properties, IAirplaneManager manager)
        {
            _simulationProperties = properties;

            _airplaneManager = manager;

            _random = new Random();
        }


        public void SpawnAirplane()
        {
            var x = 0;
            var y = 0;

            var p = _random.NextGaussian();
            x = (int)Utils.Map(p, -4, 4, -SpawnHorizon, SpawnHorizon);

            if (x > SpawnHorizon || x < -SpawnHorizon)
            {
                y = _random.Next(-SpawnHorizon, SpawnHorizon);
            }
            else
            {
                var plus = _random.NextBoolean();
                var plusy = SpawnHorizon;
                var minusy = -SpawnHorizon;
                y = plus ? plusy : minusy;
            }

            var point = new GeoPoint(x, y);
            var heading = (int)point.GetHeadingTo(new GeoPoint(0, 0));

            _airplaneManager.CreateAircraft(point, heading);
        }

        public override void AfterUpdate()
        {
            _elapsedSeconds += FrameDispatcher.DeltaTime * _simulationProperties.SimulationSpeed;

            if (!(_elapsedSeconds >= (60.0 / _simulationProperties.AircraftSpawnsPerMinute))) return;

            SpawnAirplane();
            _elapsedSeconds = 0;
        }
    }
}
