using Godot;
using System;

namespace Scenes.Buttons
{
    public partial class EntryButton : Control
    {
        [Signal] public delegate void ReceivedColorEventHandler(Color color);
        [Signal] public delegate void RemovedColorEventHandler();
        [Signal] public delegate void ClickedEventHandler();

        public Color? Color { get; private set; }

        public ColorRect ColorRect { get => GetNode<ColorRect>("ColorRect"); }

        public override void _GuiInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton mbe && mbe.ButtonIndex == MouseButton.Left && mbe.Pressed)
            {
                GD.Print("Pressed EntryButton");
                EmitSignal(SignalName.Clicked);
            }
        }

        public void ReceiveColor(Color? color)
        {
            Color = color;
            if (color == null)
            {
                EmitSignal(SignalName.RemovedColor);
            }
            else
            {
                ShaderMaterial shader = ColorRect.Material as ShaderMaterial;
                shader.SetShaderParameter("color", color.Value);
                EmitSignal(SignalName.ReceivedColor, color.Value);
            }
        }
    }
}