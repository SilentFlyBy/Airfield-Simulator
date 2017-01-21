using Airfield_Simulator.Core.Airplane;
using Airfield_Simulator.Core.FlightRoutes;
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
    public class FlightDirector : SimulationObject, IFlightDirector
    {
        public event AircraftLandedEventHandler AircraftLanded;


        private const int WAYPOINT_RADIUS = 500;
        private ISimulationProperties simulationProperties;
        private IAirplaneManager airplaneManager;
        private IRouter router;

        private Dictionary<Aircraft, Instruction> instructions;
        private double timeSinceLastInstruction;


        public FlightDirector(IAirplaneManager airplanemanager, IRouter router, ISimulationProperties simprops)
        {
            this.airplaneManager = airplanemanager;
            this.router = router;
            this.simulationProperties = simprops;
            this.instructions = new Dictionary<Aircraft, Instruction>();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public override void AfterUpdate()
        {
            CheckAllAircraft();
            IssueInstructionIfPossible();
        }

        private void IssueInstructionIfPossible()
        {
            if(timeSinceLastInstruction >= 60 / (60 * simulationProperties.SimulationSpeed))
            {
                IssueInstruction();
                timeSinceLastInstruction = 0;
            }
            timeSinceLastInstruction += FrameDispatcher.DeltaTime;
        }

        private void CheckAllAircraft()
        {
            foreach(Aircraft ac in airplaneManager.AircraftList.ToList())
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
            Instruction i = instructions[ac];
            GeoPoint targetPoint = i.Route.CurrentWaypoint;

            double targetHeading = ac.Position.GetHeadingTo(targetPoint);

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
            Instruction i = instructions[ac];

            if(ac.Position.GetDistanceTo(i.Route.CurrentWaypoint) < WAYPOINT_RADIUS)
            {
                if (i.Route.CurrentWaypoint == i.Route.Last())
                {
                    OnAircraftLanded(ac);
                    return;
                }

                i.Route.TargetNextWaypoint();
                i.Priority = 2;
            }
        }

        private void AddAircraftToListIfNew(Aircraft ac)
        {
            if (!instructions.Keys.Contains(ac))
            {
                Instruction i = new Instruction();
                i.Route = router.GetRoute(RouteDestination.Arrival, ac.Position);
                i.Priority = 1;
                this.instructions.Add(ac, i);
            }
        }

        private void IssueInstruction()
        {
            if (instructions.Count == 0)
                return;

            KeyValuePair<Aircraft, Instruction> currentInstructionPair = instructions.OrderByDescending(i => i.Value.Priority).FirstOrDefault();
            Aircraft currentInstructionAircraft = currentInstructionPair.Key;
            Instruction currentInstruction = currentInstructionPair.Value;

            if(currentInstruction.TurnDirection == TurnDirection.Left)
            {
                currentInstructionAircraft.TurnLeft(currentInstruction.TargetHeading.Value);
            }
            else if(currentInstruction.TurnDirection == TurnDirection.Right)
            {
                currentInstructionAircraft.TurnRight(currentInstruction.TargetHeading.Value);
            }

            currentInstruction.Priority = 0;
        }

        private TurnDirection GetTurnDirection(double actualheading, double targetheading)
        {
            if((targetheading - actualheading + 360) % 360 > 180)
            {
                return TurnDirection.Left;
            }
            else
            {
                return TurnDirection.Right;
            }
        }

        private void OnAircraftLanded(Aircraft ac)
        {
            if(this.AircraftLanded != null)
            {
                AircraftLanded(this, new AircraftLandedEventArgs(ac));
            }
        }
    }
}
