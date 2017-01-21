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
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Data;

namespace Airfield_Simulator
{
    public partial class MainWindow : Window
    {
        public ISimulationProperties SimProperties { get; set; }
        public ISimulationController SimController { get; set; }
        public IDrawController DrawController { get; set; }
        public Task SimulationTask { get; set; }
        public Task DrawTask { get; set; }

        private BackgroundWorker worker;
        private bool running = false;

        private List<int> fpsList;
        private int fpsCount = 0;
        private Image image_runway;

        public MainWindow()
        {
            InitializeComponent();
            image_runway = new Image();

            worker = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true
            };
            worker.DoWork += BackgroundWorkerDoWork;

            fpsList = new List<int>();


            Bindings bindings = new Bindings();

            using (IKernel kernel = new StandardKernel(bindings))
            {
                SimProperties = kernel.Get<ISimulationProperties>();
                SimProperties.SimulationSpeed = 1;
                SimProperties.InstructionsPerMinute = 10;

                var canvas = new Ninject.Parameters.ConstructorArgument("canvas", this.canvas_draw);
                SimController = kernel.Get<ISimulationController>();
                DrawController = kernel.Get<IDrawController>(canvas);
            }

            SimController.AirplaneManager.Collision += (o, e) => OnCollision();

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(Image_Runway_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            image_runway.Source = new BitmapImage(new Uri("Resources/airport_runway.jpg", UriKind.Relative));
            image_runway.MaxWidth = 500;
            image_runway.Loaded += new RoutedEventHandler(Image_Runway_Loaded);

            canvas_draw.Children.Add(image_runway);
        }

        void Image_Runway_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetBottom(image_runway, (canvas_draw.ActualHeight / 2) - (image_runway.ActualHeight /2));
            Canvas.SetLeft(image_runway, (canvas_draw.ActualWidth / 2) - (image_runway.ActualWidth /2));
        }

        public void StartSimulation()
        {
            SimController.Init(SimProperties);

            worker.RunWorkerAsync();
        }

        public void StopSimulation()
        {
            worker.CancelAsync();
        }

        private void button_start_simulation_Click(object sender, RoutedEventArgs e)
        {
            StartSimulation();
        }

        private void button_stop_simulation_Click(object sender, RoutedEventArgs e)
        {
            StopSimulation();
        }

        private void OnCollision()
        {
            StopSimulation();
            MessageBoxResult box = MessageBox.Show("Collision!");
        }

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                FrameDispatcher.UpdateFrame();

                this.Dispatcher.Invoke(() =>
                {
                    if(fpsCount > 5)
                    {
                        int sum = 0;
                        foreach(int i in fpsList)
                        {
                            sum += i;
                        }
                        label_fps.Content = sum / fpsList.Count;
                        fpsList.Clear();
                        fpsCount = 0;
                    }
                    else
                    {
                        fpsList.Add((int)(1 / FrameDispatcher.DeltaTime));
                        fpsCount++;
                    }
                });
                
            }
        }

        private void slider_simulation_speed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(SimProperties != null)
                SimProperties.SimulationSpeed = slider_simulation_speed.Value;
        }
    }
}
