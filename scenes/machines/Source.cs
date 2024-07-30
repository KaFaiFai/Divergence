using Godot;
using Scenes.Buttons;
using System;

namespace Scenes.Machines
{
    public partial class Source : Control
    {
        [Export] public Color Color { get; set; }

        public ExitButton Exit { get => this.GetNode<ExitButton>("ExitButton"); }

        public override void _Ready()
        {
            Exit.SetColor(Color);
        }
    }
}