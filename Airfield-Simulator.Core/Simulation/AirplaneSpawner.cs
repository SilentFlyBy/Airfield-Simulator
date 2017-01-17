using Airfield_Simulator.Core.Airplane;
using Airfield_Simulator.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Airfield_Simulator.Core.Simulation
{
    public class AirplaneSpawner : SimulationObject, IAirplaneSpawner
    {
        public event AirplaneSpawnEventHandler AirplaneSpawn;

        private const int SPAWN_HORIZON = 5500;
        private const int SPAWN_MAXIMUM = 10000;

        private ISimulationProperties simulationProperties;
        private IAirplaneManager AirplaneManager;
        private Random random;
        private double elapsedMilliSeconds = 0;

        public AirplaneSpawner(ISimulationProperties properties, IAirplaneManager manager)
        {
            this.simulationProperties = properties;

            this.AirplaneManager = manager;

            random = new Random();

            SpawnAirplane();
        }


        private void SpawnAirplane()
        {
            int x = 0;
            int y = 0;

            x = random.Next(-SPAWN_MAXIMUM, SPAWN_MAXIMUM);

            if(x > SPAWN_HORIZON || x < -SPAWN_HORIZON)
            {
                y = random.Next(-SPAWN_MAXIMUM, SPAWN_MAXIMUM);
            }
            else
            {
                bool plus = random.Next(2) == 0;
                int plusy = random.Next(SPAWN_HORIZON, SPAWN_MAXIMUM);
                int minusy = random.Next(-SPAWN_MAXIMUM, -SPAWN_HORIZON);
                y = plus ? plusy : minusy;
            }

            GeoPoint point = new GeoPoint(x, y);
            int heading = (int)point.GetHeadingTo(new GeoPoint(0, 0));

            AirplaneManager.CreateAircraft(point, heading);
        }

        private void OnAirplaneSpawn(Aircraft aircraft)
        {
            if (this.AirplaneSpawn != null)
                AirplaneSpawn(this, new AirplaneSpawnEventArgs(aircraft));
        }

        public override void AfterUpdate()
        {
            elapsedMilliSeconds += FrameManager.DeltaTime;
            if(elapsedMilliSeconds >= 60 / simulationProperties.AircraftSpawnsPerMinute)
            {
                SpawnAirplane();
                elapsedMilliSeconds = 0;
            }
        }
    }
}
