using Godot;
using Godot.Collections;
using Scripts;
using System;
using System.ComponentModel;

namespace Scenes.Entities
{
    public partial class Prism : Control
    {
        public ColorSource Input { get; private set; }
        public Array<ColorSource> Outputs { get; private set; }

        public Array<Marker2D> ColorComponentMarkers { get; private set; }

        private readonly PackedScene _colorScouceScene = GD.Load<PackedScene>("res://scenes/entities/ColorSource.tscn");

        public override void _Ready()
        {
            ColorComponentMarkers = new() {
                GetNode<Marker2D>("RedMarker"),
                GetNode<Marker2D>("GreenMarker"),
                GetNode<Marker2D>("BlueMarker")
            };
            Outputs = new();

            if (this.IsRunningScene())
            {
                ColorSource colorSource = _colorScouceScene.Instantiate<ColorSource>();
                colorSource.Color = new(1, 1, 1);
                ReceiveInput(colorSource);
            }
        }

        /// <summary>
        /// If input is null, it means cancel the input
        /// </summary>
        public void ReceiveInput(ColorSource input)
        {
            Input = input;
            foreach (var node in Outputs) node.QueueFree();
            Outputs.Clear();
            if (input == null) return;

            Color color = input.Color;
            for (var i = 0; i < ColorComponentMarkers.Count; i++)
            {
                if (color[i] != 0)
                {
                    Color component = new(0, 0, 0) { [i] = color[i] };
                    ColorSource colorSource = _colorScouceScene.Instantiate<ColorSource>();
                    colorSource.Color = component;
                    ColorComponentMarkers[i].AddChild(colorSource);
                    Outputs.Add(colorSource);
                }
            }
        }
    }
}