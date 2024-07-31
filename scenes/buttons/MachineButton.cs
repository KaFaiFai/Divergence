using Godot;
using System;

namespace Scenes.Buttons
{
    abstract public partial class MachineButton : Control
    {
        [Signal] public delegate void ChangedColorEventHandler(Color color);
        [Signal] public delegate void RemovedColorEventHandler();
        [Signal] public delegate void ClickedEventHandler();

        public Color? Color { get; private set; }
        public Vector2 GlobalCenter { get => GlobalPosition + Size * Scale / 2; }
        public bool Disable { get; set; } = false;

        public override void _Ready()
        {
            SetColor(null);
        }

        public override void _GuiInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton mbe && mbe.Pressed)
            {
                GD.Print("[MachineButton] Pressed");
                if (!Disable) EmitSignal(SignalName.Clicked);
            }
        }

        public virtual void SetColor(Color? color)
        {
            Color = color;
            if (color == null) EmitSignal(SignalName.RemovedColor);
            else EmitSignal(SignalName.ChangedColor, color.Value);
        }
    }
}