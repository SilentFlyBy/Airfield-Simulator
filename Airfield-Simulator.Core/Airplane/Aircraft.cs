﻿using Airfield_Simulator.Core.Models;
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
    public class Aircraft
    {
        //https://de.wikipedia.org/wiki/Standardkurve
        public const int STANDARD_RATE_TURN = 3;


        public ISimulationProperties SimulationProperties { get; set; }
        public double ActualHeading { get; private set; }
        public double ActualAltitude { get; private set; }
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
        public double ClimbRate { get; private set; }
        public AircraftType AircraftType { get; set; }
        public FlightRules FlightRules { get; set; }
        public string FlightNumber { get; set; }


        private double TargetHeading { get; set; }
        private double TargetAltitude { get; set; }

        private TurnDirection TurnDirection { get; set; }

        private double intervals_per_second
        {
            get
            {
                return 1000 / timer.Interval;
            }
        }

        private ITimer timer;



        public Aircraft(ITimer t, GeoPoint position, ISimulationProperties simprops)
        {
            timer = t;
            this.SimulationProperties = simprops;

            t.Tick += (o, args) => { OnTick(); };

            Position = position;
        }


        public void TurnLeft(double new_heading)
        {
            TurnDirection = TurnDirection.Left;
            TargetHeading = new_heading;
        }

        public void TurnRight(double new_heading)
        {
            TurnDirection = TurnDirection.Right;
            TargetHeading = new_heading;
        }

        public void ChangeHeight(double new_height)
        {
            TargetAltitude = new_height;
        }

        public void TakeOff()
        {

        }

        public void ClearToLand()
        {

        }

        public void AbortLanding()
        {

        }


        private void OnTick()
        {
            Fly();
            Turn();
            ClimbOrDescend();
        }

        private void Fly()
        {
            double traveled_distance = Speed / intervals_per_second;

            double bearing = ActualHeading * Math.PI / 180;

            Position.Latitude = Position.Latitude + traveled_distance * Math.Sin(bearing);
            Position.Longitude = Position.Longitude + traveled_distance * Math.Cos(bearing);
        }

        private void Turn()
        {
            if (ActualHeading - TargetHeading >= 1 || ActualHeading - TargetHeading <= -1)
            {
                ActualHeading = ActualHeading + (int)TurnDirection * (STANDARD_RATE_TURN / intervals_per_second) * SimulationProperties.SimulationSpeed;
            }
        }

        private void ClimbOrDescend()
        {
            if(ActualAltitude - TargetAltitude >= 10 || ActualAltitude - TargetAltitude <= 10)
            {
                if(TargetAltitude > ActualAltitude)
                {
                    Climb();
                }
                else
                {
                    Descend();
                }
            }
        }

        private void Climb()
        {
            ActualAltitude = ActualAltitude + ClimbRate / intervals_per_second;
        }

        private void Descend()
        {
            ActualAltitude = ActualAltitude - ClimbRate / intervals_per_second;
        }
    }
}
