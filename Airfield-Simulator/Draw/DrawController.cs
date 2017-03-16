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
        private Dictionary<Aircraft, Image> AircraftImageList { get; set; }
        private readonly ISimulationController _simController;
        private readonly Canvas _canvas;
        private const double ZoomFactor = 10;


        public DrawController(Canvas canvas, ISimulationController simcontroller)
        {
            this._canvas = canvas;
            this._simController = simcontroller;

            this.AircraftImageList = new Dictionary<Aircraft, Image>();

            this._simController.AircraftLanded += SimController_Aircraft_Landed;
        }

        private void SimController_Aircraft_Landed(object sender, AircraftLandedEventArgs e)
        {
            _canvas.Dispatcher.Invoke(() =>
            {
                _canvas.Children.Remove(AircraftImageList[e.Aircraft]);
            });
            
            AircraftImageList.Remove(e.Aircraft);
        }

        public override void Update()
        {
            foreach (var currentaircraft in _simController.AirplaneManager.AircraftList.ToList())
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
                var bottom = currentaircraft.Position.Y / ZoomFactor;
                var left = currentaircraft.Position.X / ZoomFactor;

                _canvas.Dispatcher.Invoke(() =>
                {
                    Canvas.SetBottom(currentimage, (bottom + _canvas.ActualHeight / 2) - (currentimage.ActualHeight / 2));
                    Canvas.SetLeft(currentimage, (left + _canvas.ActualWidth / 2) - (currentimage.ActualWidth / 2));
                    var rotate = new RotateTransform(currentaircraft.ActualHeading, 25, 25);
                    currentimage.RenderTransform = rotate;
                });
            }
        }


        private Image AddAircraft(Aircraft aircraft)
        {
            return _canvas.Dispatcher.Invoke(() =>
            {
                var image = new Image
                {
                    Source = new BitmapImage(new Uri("Resources/sep.png", UriKind.Relative))
                };

                Canvas.SetZIndex(image, 20);

                AircraftImageList.Add(aircraft, image);
                _canvas.Children.Add(image);

                return image;
            });
        }
    }
}
