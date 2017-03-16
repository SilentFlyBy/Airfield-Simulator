using Airfield_Simulator.Core;
using Airfield_Simulator.Core.Models;
using Airfield_Simulator.Core.Simulation;
using Airfield_Simulator.GUI;
using Airfield_Simulator.GUI.Draw;
using Ninject;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Windows.Media;

namespace Airfield_Simulator
{
    public partial class MainWindow : Window
    {
        private readonly BackgroundWorker _worker;

        private ISimulationProperties SimProperties { get; set; }
        private ISimulationController SimController { get; set; }
        private readonly IWeatherController _weatherController;
        private readonly List<int> _fpsList;
        private int _fpsCount;
        private double _elapsedSeconds;
        private int _landedAircraftCount;
        private readonly Image _imageRunway;
        private bool _running = false;

        public MainWindow()
        {
            InitializeComponent();
            _imageRunway = new Image();

            _worker = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true
            };
            _worker.DoWork += BackgroundWorkerDoWork;

            _fpsList = new List<int>();


            var bindings = new Bindings();

            using (IKernel kernel = new StandardKernel(bindings))
            {
                SimProperties = kernel.Get<ISimulationProperties>();
                SimProperties.SimulationSpeed = 1;
                SimProperties.InstructionsPerMinute = 10;

                var canvas = new Ninject.Parameters.ConstructorArgument("canvas", CanvasDraw);
                SimController = kernel.Get<ISimulationController>();
                kernel.Get<IDrawController>(canvas);
                _weatherController = kernel.Get<IWeatherController>();
            }

            SimController.AirplaneManager.Collision += (o, e) => OnCollision();

            Loaded += MainWindow_Loaded;
            SizeChanged += Image_Runway_Loaded;
            SimController.FlightDirector.AircraftLanded += FlightDirector_AircraftLanded;
        }

        private void FlightDirector_AircraftLanded(object sender, AircraftLandedEventArgs e)
        {
            _landedAircraftCount++;
            Dispatcher.Invoke(() =>
            {
                LabelLandedAircraftCount.Content = _landedAircraftCount;
            });
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _imageRunway.Source = new BitmapImage(new Uri("Resources/airport_runway.jpg", UriKind.Relative));
            _imageRunway.MaxWidth = 500;
            _imageRunway.Loaded += Image_Runway_Loaded;

            CanvasDraw.Children.Add(_imageRunway);
        }

        private void Image_Runway_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetBottom(_imageRunway, (CanvasDraw.ActualHeight / 2) - (_imageRunway.ActualHeight /2));
            Canvas.SetLeft(_imageRunway, (CanvasDraw.ActualWidth / 2) - (_imageRunway.ActualWidth /2));
        }

        private void StartSimulation()
        {
            SimProperties.AircraftSpawnsPerMinute = (int) SliderAircraftPerMinute.Value;
            SimProperties.InstructionsPerMinute = (int) SliderInstructionsPerMinute.Value;
            SimProperties.AircraftSpeed = (int) SliderAircraftSpeed.Value;

            SimController.Init(SimProperties);

            _worker.RunWorkerAsync();
        }

        private void StopSimulation()
        {
            _worker.CancelAsync();
        }

        private void button_start_simulation_Click(object sender, RoutedEventArgs e)
        {
            if (!_running)
            {
                _running = true;
                StartSimulation();
                SliderAircraftPerMinute.IsEnabled = false;
                SliderInstructionsPerMinute.IsEnabled = false;
                SliderAircraftSpeed.IsEnabled = false;

                ButtonStartSimulation.Content = "Stop";
                var bc = new BrushConverter();
                var brush = (Brush)bc.ConvertFrom("#FFFF7979");
                if (brush != null)
                {
                    brush.Freeze();
                    ButtonStartSimulation.Background = brush;
                }
            }
            else
            {
                _running = false;
                StopSimulation();

                ButtonStartSimulation.Content = "Start";
                var bc = new BrushConverter();
                var brush = (Brush)bc.ConvertFrom("#FF5FFF77");
                if (brush != null)
                {
                    brush.Freeze();
                    ButtonStartSimulation.Background = brush;
                }
            }
        }

        private void OnCollision()
        {
            StopSimulation();
            MessageBoxResult box = MessageBox.Show("Kollision!");
        }

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            while (!_worker.CancellationPending)
            {
                FrameDispatcher.UpdateFrame();

                Dispatcher.Invoke(() =>
                {
                    if(_fpsCount > 100)
                    {
                        var sum = _fpsList.Sum();
                        LabelFps.Content = sum / _fpsList.Count;
                        _fpsList.Clear();
                        _fpsCount = 0;
                    }
                    else
                    {
                        _fpsList.Add((int)(1 / FrameDispatcher.DeltaTime));
                        _fpsCount++;
                    }

                    _elapsedSeconds += FrameDispatcher.DeltaTime * SimProperties.SimulationSpeed;
                    LabelTime.Content = string.Format("{0:00.000 s}", _elapsedSeconds);
                    LabelWind.Content = _weatherController.WindDegrees;
                    LabelAircraftCount.Content = SimController.AirplaneManager.AircraftList.Count;

                    if (_elapsedSeconds > 300)
                    {
                        StopSimulation();
                        MessageBox.Show("Simulation erfolgreich beendet!");
                    }
                });
                
            }
        }

        private void slider_simulation_speed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(SimProperties != null)
                SimProperties.SimulationSpeed = SliderSimulationSpeed.Value;
        }

        private void SliderInstructionsPerMinute_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(SimProperties != null)
            {
                SimProperties.InstructionsPerMinute = (int)SliderInstructionsPerMinute.Value;
            }
        }

        private void SliderAircraftPerMinute_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SimProperties != null)
            {
                SimProperties.AircraftSpawnsPerMinute = (int)SliderAircraftPerMinute.Value;
            }
        }

        private void SliderAircraftSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SimProperties != null)
            {
                SimProperties.AircraftSpeed = (int) SliderAircraftSpeed.Value;
            }
        }
    }
}
