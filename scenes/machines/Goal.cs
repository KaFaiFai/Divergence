using Godot;
using Scenes.Buttons;
using Scripts;
using System;

namespace Scenes.Machines
{
    public partial class Goal : Draggable
    {
        [Signal] public delegate void ReceivedInputEventHandler();

        [Export] public Color TargetColor { get; set; }
        public bool IsCorrect { get => Entry.Color == TargetColor; }

        public EntryButton Entry { get => GetNode<EntryButton>("VBoxContainer/EntryButton"); }
        public Polygon2D FlagLogo { get => GetNode<Polygon2D>("VBoxContainer/Spacer/Control/FlagLogo"); }

        public override void _Ready()
        {
            base._Ready();
            Entry.ChangedColor += (color) => OnNewColor(color);
            Entry.RemovedColor += () => OnNewColor(null);
            FlagLogo.Color = TargetColor;

            if (this.IsRunningScene())
            {
                Entry.SetColor(new(1, 1, 1));
            }
        }

        private void OnNewColor(Color? color)
        {
            EmitSignal(SignalName.ReceivedInput);
        }
    }
}
