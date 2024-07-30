using Godot;
using System;

namespace Scenes.Entities
{
    public partial class ColorSource : Control
    {
        private Color _color;
        public Color Color { get => _color; set { _color = value; UpdateColor(); } }

        public ColorRect ColorRect { get => GetNode<ColorRect>("ColorRect"); }

        public override void _Ready()
        {
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
        }

        private void UpdateColor()
        {
            ShaderMaterial shader = ColorRect.Material as ShaderMaterial;
            shader.SetShaderParameter("color", Color);
        }
    }
}