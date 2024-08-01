using Godot;
using System;

namespace Scenes.Buttons
{
    public partial class ExitButton : MachineButton
    {
        public ColorRect ColorRect { get => GetNode<ColorRect>("ColorRect"); }
        public Label ColorLabel { get => GetNode<Label>("ColorLabel"); }

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
            MouseEntered += () => UpdateDisplay(rotate: true, showText: true);
            MouseExited += () => UpdateDisplay(showText: false);

            SetColor(null);
            ColorLabel.Visible = false;
        }

        private void UpdateDisplay(Color? color = null, bool? rotate = null, bool? showText = null)
        {
            Color colorValue = color ?? Color ?? new Color(0, 0, 0);
            ColorRect.Material.Set("shader_parameter/color", colorValue);
            bool rotateValue = rotate ?? Color != null;
            ColorRect.Material.Set("shader_parameter/rotate", rotateValue);

            if (showText == true)
            {
                ColorLabel.Visible = true;
                ColorLabel.Text = $"R: {colorValue.R:F2}| G: {colorValue.G:F2}| B: {colorValue.B:F2}";
            }
            else if (showText == false)
            {
                ColorLabel.Visible = false;
            }
        }
    }
}