using Godot;
using Scenes.Buttons;
using Scripts;
using System;

namespace Scenes.Machines
{
    public partial class Goal : Draggable
    {
        [Signal] public delegate void ColoredEventHandler();

        [Export] public Color TargetColor { get; set; }

        public EntryButton Entry { get => GetNode<EntryButton>("VBoxContainer/EntryButton"); }
        public Polygon2D FlagLogo { get => GetNode<Polygon2D>("VBoxContainer/Spacer/Control/FlagLogo"); }

        public override void _Ready()
        {
            base._Ready();
            Entry.ColorChanged += (color) => OnNewColor(color);
            Entry.ColorRemoved += () => OnNewColor(null);
            FlagLogo.Color = TargetColor;

            if (this.IsRunningScene())
            {
                Entry.SetColor(new(1, 1, 1));
            }
        }

        public bool IsCorrect() => Entry.Color == TargetColor;

        private void OnNewColor(Color? color)
        {
            EmitSignal(SignalName.Colored);
        }
    }
}
