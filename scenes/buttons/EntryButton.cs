using Godot;
using System;

namespace Scenes.Buttons
{
    public partial class EntryButton : MachineButton
    {
        public ColorRect ColorRect { get => GetNode<ColorRect>("ColorRect"); }

        public override void _Ready()
        {
            base._Ready();
            ColorChanged += (color) => UpdateDisplay(color: color);
            ColorRemoved += () => UpdateDisplay();
            MouseEntered += () => UpdateDisplay(rotate: true);
            MouseExited += () => UpdateDisplay();
            //ConnectionCreated += (edge) => UpdateDisplay();
            //ConnectionRemoved += () => UpdateDisplay();

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