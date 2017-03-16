using System;
using System.Collections.Generic;
using System.Linq;
using Airfield_Simulator.Core.Airplane;
using Airfield_Simulator.Core.FlightRoutes;
using Airfield_Simulator.Core.Models;

namespace Airfield_Simulator.Core.Simulation
{
    public class FlightDirector : SimulationObject, IFlightDirector
    {
        private const int WaypointRadius = 500;
        private readonly IAirplaneManager _airplaneManager;

        private readonly Dictionary<Aircraft, Instruction> _instructions;
        private readonly IRouter _router;
        private readonly ISimulationProperties _simulationProperties;
        private double _timeSinceLastInstruction;
        private bool _canIssueInstruction = true;

        public event AircraftLandedEventHandler AircraftLanded;


        public FlightDirector(IAirplaneManager airplanemanager, IRouter router, ISimulationProperties simprops)
        {
            _airplaneManager = airplanemanager;
            this._router = router;
            _simulationProperties = simprops;
            _instructions = new Dictionary<Aircraft, Instruction>();
        }


        public override void AfterUpdate()
        {
            CheckAllAircraft();
            IssueInstructionIfPossible();
        }

        private void IssueInstructionIfPossible()
        {
            if (_timeSinceLastInstruction >= (60 / (double)_simulationProperties.InstructionsPerMinute) / _simulationProperties.SimulationSpeed)
            {
                _canIssueInstruction = true;
            }
            if (_canIssueInstruction)
            {
                IssueInstruction();
            }
            _timeSinceLastInstruction += FrameDispatcher.DeltaTime;
        }

        private void CheckAllAircraft()
        {
            foreach (var ac in _airplaneManager.AircraftList.ToList())
            {
                AddAircraftToListIfNew(ac);
                UpdateAircraftInstruction(ac);
            }
        }

        private void UpdateAircraftInstruction(Aircraft ac)
        {
            UpdateAircraftTargetPoint(ac);
            UpdateAircraftTargetHeading(ac);
        }

        private void UpdateAircraftTargetHeading(Aircraft ac)
        {
            var i = _instructions[ac];
            var targetPoint = i.Route.CurrentWaypoint;

            var targetHeading = ac.Position.GetHeadingTo(targetPoint);

            if (Utils.OutOfToleranceRange(targetHeading, ac.TargetHeading, 10))
            {
                i.Priority = 1;
                i.TurnDirection = GetTurnDirection(ac.ActualHeading, targetHeading);

                i.TargetHeading = targetHeading;
            }
            else
            {
                i.Priority = 0;
            }
        }

        private void UpdateAircraftTargetPoint(Aircraft ac)
        {
            var i = _instructions[ac];

            if (ac.Position.GetDistanceTo(i.Route.CurrentWaypoint) > WaypointRadius) return;
            if (i.Route.CurrentWaypoint == i.Route.Last())
            {
                OnAircraftLanded(ac);
                return;
            }

            i.Route.TargetNextWaypoint();
            i.Priority = 2;
        }

        private void AddAircraftToListIfNew(Aircraft ac)
        {
            if (_instructions.Keys.Contains(ac)) return;

            var i = new Instruction
            {
                Route = _router.GetRoute(RouteDestination.Arrival, ac.Position),
                Priority = 1
            };
            _instructions.Add(ac, i);
        }

        private void IssueInstruction()
        {
            if (_instructions.Count == 0)
                return;

            var currentInstructionPair = _instructions.OrderByDescending(i => i.Value.Priority).FirstOrDefault();
            var currentInstructionAircraft = currentInstructionPair.Key;
            var currentInstruction = currentInstructionPair.Value;

            switch (currentInstruction.TurnDirection)
            {
                case TurnDirection.Left:
                    if (currentInstruction.TargetHeading != null)
                        currentInstructionAircraft.TurnLeft(currentInstruction.TargetHeading.Value);
                    break;
                case TurnDirection.Right:
                    if (currentInstruction.TargetHeading != null)
                        currentInstructionAircraft.TurnRight(currentInstruction.TargetHeading.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            currentInstruction.Priority = 0;

            _canIssueInstruction = false;
            _timeSinceLastInstruction = 0;
        }

        private TurnDirection GetTurnDirection(double actualheading, double targetheading)
        {
            if ((targetheading - actualheading + 360)%360 > 180)
            {
                return TurnDirection.Left;
            }
            return TurnDirection.Right;
        }

        private void OnAircraftLanded(Aircraft ac)
        {
            AircraftLanded?.Invoke(this, new AircraftLandedEventArgs(ac));
        }
    }
}