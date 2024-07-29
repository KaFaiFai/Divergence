using Godot;
using System;

namespace Scenes.Entities
{
    public partial class ColorPortal : Node2D
    {
        [Export] public Color Color { get; set; }

        public override void _Ready()
        {
            Modulate = Color;
        }
    }
}