using Airfield_Simulator.Core.Models;
using Airfield_Simulator.Core.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Airfield_Simulator.Core.Airplane
{
    public class Aircraft : SimulationObject
    {
        public const int STANDARD_RATE_TURN = 10;


        public ISimulationProperties SimulationProperties { get; set; }
        private double actualHeading;
        public double ActualHeading
        {
            get
            {
                return actualHeading;
            }
            set
            {
                if(IsValidHeading(value))
                {
                    actualHeading = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Value must be between 0 and 360");
                }
            }
        }
        public GeoPoint Position { get; private set; }

        private double _speed = 90;
        public double Speed
        {
            get
            {
                return _speed * SimulationProperties.SimulationSpeed;
            }
            set
            {
                _speed = value;
            }
        }

        public double TargetHeading { get; private set; }

        private TurnDirection TurnDirection;




        public Aircraft(GeoPoint position, int heading, ISimulationProperties simprops)
        {
            this.SimulationProperties = simprops;


            Position = position;
            ActualHeading = heading;
        }


        public void TurnLeft(double new_heading)
        {
            TurnDirection = TurnDirection.Left;

            if (IsValidHeading(new_heading))
            {
                TargetHeading = new_heading;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Value must be between 0 and 360");
            }
        }

        public void TurnRight(double new_heading)
        {
            TurnDirection = TurnDirection.Right;

            if(IsValidHeading(new_heading))
            {
                TargetHeading = new_heading;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Value must be between 0 and 259");
            }
        }

        public override void BeforeUpdate()
        {
            Fly();
            Turn();
        }

        private void Fly()
        {
            double traveled_distance = Speed * FrameDispatcher.DeltaTime;

            double bearing = ActualHeading * Math.PI / 180;

            Position.Y = Math.Round(Position.Y + traveled_distance * Math.Cos(bearing), 5);
            Position.X = Math.Round(Position.X + traveled_distance * Math.Sin(bearing), 5);
        }

        private void Turn()
        {
            if (ActualHeading - TargetHeading >= 0.2 || ActualHeading - TargetHeading <= -0.2)
            {
                double tempheading = ActualHeading + (int)TurnDirection * (STANDARD_RATE_TURN * FrameDispatcher.DeltaTime) * SimulationProperties.SimulationSpeed;
                if(tempheading < 0)
                {
                    ActualHeading = 360 + tempheading;
                }
                else if(tempheading >= 360)
                {
                    ActualHeading = tempheading - 360;
                }
                else
                {
                    ActualHeading = tempheading;
                }
            }
        }


        private bool IsValidHeading(double d)
        {
            if(d < 0 || d > 360)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
