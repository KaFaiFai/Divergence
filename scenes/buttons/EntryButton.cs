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
            ChangedColor += (color) => ColorRect.Material.Set("shader_parameter/color", color);
            RemovedColor += () => ColorRect.Material.Set("shader_parameter/color", new Color(0, 0, 0));

            SetColor(null);
        }
    }
}