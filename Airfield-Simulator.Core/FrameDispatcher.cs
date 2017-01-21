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

        private static List<SimulationObject> UpdateObjects;
        private static Stopwatch stopWatch;

        static FrameDispatcher()
        {
            UpdateObjects = new List<SimulationObject>();
            stopWatch = new Stopwatch();
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
            stopWatch.Restart();
            lock (UpdateObjects)
            {
                foreach (SimulationObject update in UpdateObjects.ToList())
                {
                    if (update != null)
                        update.BeforeUpdate();
                }
                foreach (SimulationObject update in UpdateObjects.ToList())
                {
                    if (update != null)
                        update.Update();
                }
                foreach (SimulationObject update in UpdateObjects.ToList())
                {
                    if (update != null)
                        update.AfterUpdate();
                }
            }
            Thread.Sleep(2);
            
            stopWatch.Stop();

            DeltaTime = stopWatch.Elapsed.TotalMilliseconds / 1000;
        }
    }
}
