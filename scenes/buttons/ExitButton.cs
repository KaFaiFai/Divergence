using Godot;
using System;

namespace Scenes.Buttons
{
    public partial class ExitButton : MachineButton
    {
        public ColorRect ColorRect { get => GetNode<ColorRect>("ColorRect"); }

        public override void _Ready()
        {
            base._Ready();
            ColorChanged += (color) =>
            {
                Disable = false; 
                UpdateDisplay(color: color);
            };
            ColorRemoved += () =>
            {
                Disable = true;
                UpdateDisplay();
            };
            MouseEntered += () => UpdateDisplay(rotate: true);
            MouseExited += () => UpdateDisplay();

            SetColor(null);
        }

        private void UpdateDisplay(Color? color = null, bool? rotate = null)
        {
            Color colorValue = color ?? Color ?? new Color(0, 0, 0);
            ColorRect.Material.Set("shader_parameter/color", colorValue);
            bool rotateValue = rotate ?? Color != null;
            ColorRect.Material.Set("shader_parameter/rotate", rotateValue);
        }
    }
}