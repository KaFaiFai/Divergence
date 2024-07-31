using Godot;
using Scenes.Edges;
using System;

namespace Scenes.Buttons
{
    abstract public partial class MachineButton : Control
    {
        [Signal] public delegate void ColorChangedEventHandler(Color color);
        [Signal] public delegate void ColorRemovedEventHandler();
        [Signal] public delegate void ClickedEventHandler();

        public Color? Color { get; private set; }
        public Vector2 GlobalCenter { get => GlobalPosition + GetGlobalTransform().BasisXform(Size) / 2; }
        public bool Disable { get; set; } = false;

        public override void _Ready()
        {
            SetColor(null);
        }

        public override void _GuiInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton mbe && mbe.Pressed)
            {
                GD.Print($"[MachineButton] Pressed {GlobalCenter}, {GetGlobalMousePosition()}");
                if (!Disable) EmitSignal(SignalName.Clicked);
            }
        }

        public virtual void SetColor(Color? color)
        {
            Color = color;
            if (color == null) EmitSignal(SignalName.ColorRemoved);
            else EmitSignal(SignalName.ColorChanged, color.Value);
        }
    }
}