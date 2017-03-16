using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.Core
{
    public abstract class SimulationObject
    {
        protected SimulationObject()
        {
            FrameDispatcher.AddUpdateObject(this);
        }

        ~SimulationObject()
        {
            FrameDispatcher.RemoveUpdateObject(this);
        }


        public virtual void BeforeUpdate()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void AfterUpdate()
        {

        }
    }
}
