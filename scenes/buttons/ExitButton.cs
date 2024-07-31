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
            ChangedColor += (color) =>
            {
                Disable = false;
                ColorRect.Material.Set("shader_parameter/color", color);
            };
            RemovedColor += () =>
            {
                Disable = true;
                ColorRect.Material.Set("shader_parameter/color", new Color(0, 0, 0));
            };

            SetColor(null);
        }
    }
}