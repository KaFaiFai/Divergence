using Godot;
using Scenes.Buttons;
using Scripts;
using System;

namespace Scenes.Machines
{
    public partial class Source : Draggable
    {
        [Export] public Color Color { get; set; }

        public ExitButton Exit { get => GetNode<ExitButton>("VBoxContainer/ExitButton"); }

        public override void _Ready()
        {
            base._Ready();
            Exit.SetColor(Color);
        }
    }
}