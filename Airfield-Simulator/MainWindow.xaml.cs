﻿using Airfield_Simulator.Core;
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

namespace Airfield_Simulator
{
    public partial class MainWindow : Window
    {
        public ISimulationProperties SimProperties { get; set; }
        public ISimulationController SimController { get; set; }
        public IDrawController DrawController { get; set; }
        public Task SimulationTask { get; set; }
        public Task DrawTask { get; set; }



        public MainWindow()
        {
            InitializeComponent();

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

            canvas_draw.MouseMove += (o, args) =>
            {
                ShowMousePosition();
            };
        }

        public void StartSimulation()
        {
            canvas_draw.Children.Clear();
            SimController.Init(SimProperties);
            SimController.Start();

            DrawController.StartDrawLoop();
        }

        public void StopSimulation()
        {
            SimController.Stop();
            DrawController.StopDrawLoop();
        }

        private void ShowMousePosition()
        {
            Point p = Mouse.GetPosition(canvas_draw);

            label_mouse.Content = string.Format("{0:0}",p.X) + ", " + string.Format("{0:0}", p.Y);
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
            SimController.Stop();
            MessageBoxResult box = MessageBox.Show("Collision!");
            
        }
    }
}
