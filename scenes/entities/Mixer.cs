using Godot;
using Godot.Collections;
using System;

namespace Scenes.Entities
{
    public partial class Mixer : Control
    {
        public Array<ColorSource> Inputs { get; private set; }
        public ColorSource Output { get; private set; }

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
        }
    }
}