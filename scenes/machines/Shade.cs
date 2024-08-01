using Godot;
using Scenes.Buttons;
using Scripts;
using System;

namespace Scenes.Machines
{
    public partial class Shade : Draggable
    {
        public EntryButton Entry { get => GetNode<EntryButton>("HBoxContainer/EntryButton"); }
        public ExitButton Exit { get => GetNode<ExitButton>("HBoxContainer/ExitButton"); }
        public HSlider HSlider { get => GetNode<HSlider>("HBoxContainer/Spacer/Control/HSlider"); }

        public override void _Ready()
        {
            base._Ready();
            Entry.ColorChanged += (color) => OnNewColor(color);
            Entry.ColorRemoved += () => OnNewColor(null);
            HSlider.ValueChanged += (_) => OnNewColor(null);

            if (this.IsRunningScene())
            {
                Entry.SetColor(new(0, 1, 0));
            }
        }

        private void OnNewColor(Color? color)
        {
            Color? entryColor = color ?? Entry.Color;
            if (entryColor == null)
            {
                Exit.SetColor(null);
            }
            else
            {
                Color c = entryColor.Value;
                Color tint = ColorOp.AddShade(c, (float)HSlider.Value);
                Exit.SetColor(tint);
            }
        }
    }
}
