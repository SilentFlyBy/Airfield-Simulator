using Airfield_Simulator.Core;
using Airfield_Simulator.Core.FlightRoutes;
using Airfield_Simulator.Core.Models;
using Airfield_Simulator.Core.Simulation;
using Airfield_Simulator.GUI.Draw;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airfield_Simulator.GUI
{
    public class Bindings : NinjectModule
    {
        private ISimulationProperties simProperties;


        public Bindings(ISimulationProperties simprops)
        {
            this.simProperties = simprops;
        }


        public override void Load()
        {
            Bind<ISimulationController>().To<SimulationController>().InSingletonScope().WithConstructorArgument("simprops", this.simProperties);
            Bind<IAirplaneManager>().To<AirplaneManager>().InSingletonScope().WithConstructorArgument("simprops", this.simProperties);
            Bind<IFlightDirector>().To<FlightDirector>().InSingletonScope();
            Bind<ITimer>().To<SimulationTimer>().InSingletonScope();
            Bind<IDrawController>().To<DrawController>().InSingletonScope().WithConstructorArgument("canvas");
            Bind<IRouter>().To<Router>().InSingletonScope();
            Bind<IWeatherController>().To<WeatherController>();
        }
    }
}
