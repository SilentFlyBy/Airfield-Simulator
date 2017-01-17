using Airfield_Simulator.Core;
using Airfield_Simulator.Core.Airplane;
using Airfield_Simulator.Core.Models;
using Airfield_Simulator.Core.Simulation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Airfield_Simulator.GUI.Draw
{
    public class DrawController : SimulationObject, IDrawController
    {
        public Dictionary<Aircraft, Image> AircraftImageList { get; set; }
        public double SimulationSpeed { get; set; }
        
        private ISimulationController simController;
        private Canvas canvas;
        private double ZoomFactor = 10;


        public DrawController(Canvas canvas, ISimulationController simcontroller)
        {
            this.canvas = canvas;
            this.simController = simcontroller;

            this.AircraftImageList = new Dictionary<Aircraft, Image>();
        }


        public override void Update()
        {
            foreach (Aircraft currentaircraft in simController.AirplaneManager.AircraftList.ToList())
            {
                Image currentimage = null;

                if (AircraftImageList.ContainsKey(currentaircraft))
                {
                    currentimage = AircraftImageList[currentaircraft];
                }
                else
                {
                    currentimage = AddAircraft(currentaircraft);
                }
                double bottom = currentaircraft.Position.Y / ZoomFactor;
                double left = currentaircraft.Position.X / ZoomFactor;

                canvas.Dispatcher.Invoke(() =>
                {
                    Canvas.SetBottom(currentimage, bottom + canvas.ActualHeight / 2);
                    Canvas.SetLeft(currentimage, left + canvas.ActualWidth / 2);
                    RotateTransform rotate = new RotateTransform(currentaircraft.ActualHeading, 25, 25);
                    currentimage.RenderTransform = rotate;
                });
            }
        }


        private Image AddAircraft(Aircraft aircraft)
        {
            return canvas.Dispatcher.Invoke(() =>
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("Resources/sep.png", UriKind.Relative));

                AircraftImageList.Add(aircraft, image);
                canvas.Children.Add(image);

                return image;
            });
        }

        private void removeAircraft(Aircraft aircraft)
        {

        }
    }
}
