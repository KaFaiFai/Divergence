using Godot;
using Scenes.Buttons;
using System;

namespace Scenes.Machines
{
    public partial class Source : Control
    {
        [Export] public Color Color { get; set; }

        public ExitButton Exit { get => GetNode<ExitButton>("VBoxContainer/ExitButton"); }

        public override void _Ready()
        {
            Exit.SetColor(Color);
        }
    }
}