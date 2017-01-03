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
    public class DrawController : IDrawController
    {
        public const double FRAMERATE = 60;

        public Dictionary<Aircraft, Image> AircraftImageList { get; set; }
        public double SimulationSpeed { get; set; }
        
        private ITimer _drawTimer;
        private ISimulationController _simController;
        private Canvas _canvas;
        private double ZoomFactor = 10;


        public DrawController(ITimer timer, Canvas canvas, ISimulationController simcontroller)
        {
            this._canvas = canvas;
            this._simController = simcontroller;
            this._drawTimer = timer;

            this.AircraftImageList = new Dictionary<Aircraft, Image>();

            _drawTimer.Tick += (o, args) => { OnDrawTimerTick(); };
        }

        public void StartDrawLoop()
        {
            _drawTimer.Start();
        }

        public void StopDrawLoop()
        {
            _drawTimer.Stop();
        }

        private void OnDrawTimerTick()
        {
            foreach(Aircraft currentaircraft in _simController.AirplaneManager.AircraftList.ToList())
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

                Canvas.SetBottom(currentimage, bottom + _canvas.ActualHeight/2);
                Canvas.SetLeft(currentimage, left + _canvas.ActualWidth/2);
                RotateTransform rotate = new RotateTransform(currentaircraft.ActualHeading, 25, 25);
                currentimage.RenderTransform = rotate;
            }
        }

        private Image AddAircraft(Aircraft aircraft)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("Resources/sep.png", UriKind.Relative));

            AircraftImageList.Add(aircraft, image);
            _canvas.Children.Add(image);

            return image;
        }

        private void removeAircraft(Aircraft aircraft)
        {

        }
    }
}
