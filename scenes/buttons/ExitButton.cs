using Godot;
using System;

namespace Scenes.Buttons
{
    public partial class ExitButton : Control
    {
        [Signal] public delegate void NewColorEventHandler(Color color);
        [Signal] public delegate void ClearedColorEventHandler();
        [Signal] public delegate void ClickedEventHandler();

        public Color? Color { get; private set; }
        public bool Disable { get => Color == null; }

        public ColorRect ColorRect { get => GetNode<ColorRect>("ColorRect"); }

        public override void _GuiInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton mbe && mbe.ButtonIndex == MouseButton.Left && mbe.Pressed)
            {
                GD.Print("Pressed ExitButton");
                if (!Disable) EmitSignal(SignalName.Clicked);
            }
        }

        public void SetColor(Color? color)
        {
            Color = color;
            ShaderMaterial shader = ColorRect.Material as ShaderMaterial;
            if (color == null)
            {
                shader.SetShaderParameter("color", new Color(0, 0, 0));
                EmitSignal(SignalName.ClearedColor);
            }
            else
            {
                shader.SetShaderParameter("color", color.Value);
                EmitSignal(SignalName.NewColor, color.Value);
            }
        }
    }
}