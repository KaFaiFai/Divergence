using Godot;
using Scenes.Buttons;
using Scripts;
using System;

namespace Scenes.Machines
{
    public partial class Goal : Control
    {
        [Signal] public delegate void ReceivedInputEventHandler();

        [Export] public Color TargetColor { get; set; }
        public bool IsCorrect { get => Entry.Color == TargetColor; }

        public EntryButton Entry { get => this.GetNode<EntryButton>("EntryButton"); }
        public Polygon2D Polygon { get => this.GetNode<Polygon2D>("Polygon2D"); }

        public override void _Ready()
        {
            Entry.ReceivedColor += (color) => OnNewColor(color);
            Entry.RemovedColor += () => OnNewColor(null);
            Polygon.Color = TargetColor;

            if (this.IsRunningScene())
            {
                Entry.ReceiveColor(new(1, 1, 1));
            }
        }

        private void OnNewColor(Color? color)
        {
            EmitSignal(SignalName.ReceivedInput);
        }
    }
}
