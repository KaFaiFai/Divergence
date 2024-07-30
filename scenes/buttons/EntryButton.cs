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
        public Vector2 GlobalCenter { get => GlobalPosition + Size * Scale / 2; }

        public ColorRect ColorRect { get => GetNode<ColorRect>("ColorRect"); }

        public override void _Ready()
        {
            ReceiveColor(null);
        }

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
            ShaderMaterial shader = ColorRect.Material as ShaderMaterial;
            if (color == null)
            {
                shader.SetShaderParameter("color", new Color(0, 0, 0));
                EmitSignal(SignalName.RemovedColor);
            }
            else
            {
                shader.SetShaderParameter("color", color.Value);
                EmitSignal(SignalName.ReceivedColor, color.Value);
            }
        }
    }
}