using Godot;
using System;

namespace Scripts
{
    public partial class Draggable : Control
    {
        [Signal] public delegate void DragStartedEventHandler();
        [Signal] public delegate void DragEndedEventHandler();

        public bool IsDragging { get; private set; }
        public Vector2 DragRelativePosition { get; private set; }

        public override void _Process(double delta)
        {
            base._Process(delta);
            if (IsDragging)
            {
                SetGlobalPosition(GetGlobalMousePosition() - DragRelativePosition);
            }
        }

        public override void _GuiInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton mbe && mbe.ButtonIndex == MouseButton.Left)
            {
                if (mbe.Pressed)
                {
                    GD.Print("[Draggable] DragStarted");
                    EmitSignal(SignalName.DragStarted);
                    IsDragging = true;
                    DragRelativePosition = GetGlobalMousePosition() - GlobalPosition;
                }
                else
                {
                    GD.Print("[Draggable] DragEnded");
                    EmitSignal(SignalName.DragEnded);
                    IsDragging = false;
                    DragRelativePosition = Vector2.Zero;
                }
            }
        }
    }
}