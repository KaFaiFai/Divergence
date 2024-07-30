using Godot;
using Scenes.Entities;
using System;

namespace Scenes.Machines
{
    public partial class EntryButton : Control
    {
        [Signal] public delegate void ReceivedColorEventHandler(Color color);
        [Signal] public delegate void ClickedEventHandler();

        public override void _GuiInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton mbe && mbe.ButtonIndex == MouseButton.Left && mbe.Pressed)
            {
                EmitSignal(SignalName.Clicked);
            }
        }

        public void ReceiveColor(Color color)
        {
            EmitSignal(SignalName.ReceivedColor, color);
        }
    }
}