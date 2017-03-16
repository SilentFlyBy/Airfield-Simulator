using System;
using System.Windows.Forms;
using Airfield_Simulator.Core.Models;

namespace Airfield_Simulator.Core.Airplane
{
    public class Aircraft : SimulationObject
    {
        public ISimulationProperties SimulationProperties { get; }
        public GeoPoint Position { get; }
        public double TargetHeading { get; private set; }

        private double TrueSpeed => Speed * SimulationProperties.SimulationSpeed;
        private const int StandardRateTurn = 30;
        private double Speed => SimulationProperties.AircraftSpeed;
        private double _actualHeading;
        private TurnDirection _turnDirection;


        public Aircraft(GeoPoint position, int heading, ISimulationProperties simprops)
        {
            SimulationProperties = simprops;


            Position = position;
            ActualHeading = heading;
        }



        public double ActualHeading
        {
            get { return _actualHeading; }
            set
            {
                if (IsValidHeading(value))
                {
                    _actualHeading = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 360");
                }
            }
        }

        public void TurnLeft(double newHeading)
        {
            _turnDirection = TurnDirection.Left;

            if (IsValidHeading(newHeading))
            {
                TargetHeading = newHeading;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(newHeading), "Value must be between 0 and 360");
            }
        }

        public void TurnRight(double newHeading)
        {
            _turnDirection = TurnDirection.Right;

            if (IsValidHeading(newHeading))
            {
                TargetHeading = newHeading;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(newHeading), "Value must be between 0 and 259");
            }
        }

        public override void BeforeUpdate()
        {
            Fly();
            Turn();
        }

        private void Fly()
        {
            var traveledDistance = TrueSpeed*FrameDispatcher.DeltaTime;

            var bearing = ActualHeading*Math.PI/180;

            Position.Y = Math.Round(Position.Y + traveledDistance*Math.Cos(bearing), 5);
            Position.X = Math.Round(Position.X + traveledDistance*Math.Sin(bearing), 5);
        }

        private void Turn()
        {
            if (!(ActualHeading - TargetHeading >= 0.2) && !(ActualHeading - TargetHeading <= -0.2))
                return;

            var tempheading = ActualHeading +
                              (int) _turnDirection*(StandardRateTurn*FrameDispatcher.DeltaTime)*
                              SimulationProperties.SimulationSpeed;
            if (tempheading < 0)
            {
                ActualHeading = 360 + tempheading;
            }
            else if (tempheading >= 360)
            {
                ActualHeading = tempheading - 360;
            }
            else
            {
                ActualHeading = tempheading;
            }
        }


        private static bool IsValidHeading(double d)
        {
            return (d >= 0) && (d < 360);
        }
    }
}