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

        private static List<IUpdateFrame> UpdateObjects;
        private static Stopwatch stopWatch;

        static FrameManager()
        {
            UpdateObjects = new List<IUpdateFrame>();
            stopWatch = new Stopwatch();
            DeltaTime = 0;
        }

        public static void AddUpdateObject(IUpdateFrame update)
        {
            UpdateObjects.Add(update);
        }

        public static void UpdateFrame()
        {
            stopWatch.Restart();
            lock (UpdateObjects)
            {
                foreach (IUpdateFrame update in UpdateObjects.ToList())
                {
                    if (update != null)
                        update.UpdateFrame();
                }
            }
            Thread.Sleep((int)(16 - DeltaTime));
            
            stopWatch.Stop();

            DeltaTime = stopWatch.Elapsed.TotalMilliseconds / 1000;
        }
    }
}
