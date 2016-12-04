using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.GUI.Draw
{
    public interface IDrawController
    {
        void StartDrawLoop();
        void StopDrawLoop();
    }
}
