using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core
{
    public static class FrameManager
    {
        public static double DeltaTime { get; set; }

        private static List<SimulationObject> UpdateObjects;
        private static Stopwatch stopWatch;

        static FrameManager()
        {
            UpdateObjects = new List<SimulationObject>();
            stopWatch = new Stopwatch();
            DeltaTime = 0;
        }

        public static void AddUpdateObject(SimulationObject update)
        {
            UpdateObjects.Add(update);
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
            Thread.Sleep((int)(5 - DeltaTime));
            
            stopWatch.Stop();

            DeltaTime = stopWatch.Elapsed.TotalMilliseconds / 1000;
        }
    }
}
