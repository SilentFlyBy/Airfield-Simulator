using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core
{
    public static class FrameDispatcher
    {
        public static double DeltaTime { get; set; }

        private static readonly List<SimulationObject> UpdateObjects;
        private static readonly Stopwatch StopWatch;

        static FrameDispatcher()
        {
            UpdateObjects = new List<SimulationObject>();
            StopWatch = new Stopwatch();
            DeltaTime = 0;
        }

        public static void AddUpdateObject(SimulationObject update)
        {
            if(!UpdateObjects.Contains(update))
                UpdateObjects.Add(update);
        }

        public static void RemoveUpdateObject(SimulationObject update)
        {
            if (!UpdateObjects.Contains(update))
                UpdateObjects.Remove(update);
        }

        public static void UpdateFrame()
        {
            StopWatch.Restart();
            lock (UpdateObjects)
            {
                foreach (var update in UpdateObjects.ToList())
                {
                    update?.BeforeUpdate();
                }
                foreach (var update in UpdateObjects.ToList())
                {
                    update?.Update();
                }
                foreach (var update in UpdateObjects.ToList())
                {
                    update?.AfterUpdate();
                }
            }
            Thread.Sleep(2);
            
            StopWatch.Stop();

            DeltaTime = StopWatch.Elapsed.TotalMilliseconds / 1000;
        }
    }
}
