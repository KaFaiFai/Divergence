using Godot;
using Godot.Collections;
using Scenes.Buttons;
using Scripts;
using System;

namespace Scenes.Machines
{
    public partial class Mixer : Draggable
    {
        public EntryButton Entry1 { get => GetNode<EntryButton>("VBoxContainer/HBoxContainer/EntryButton1"); }
        public EntryButton Entry2 { get => GetNode<EntryButton>("VBoxContainer/HBoxContainer/EntryButton2"); }
        public ExitButton Exit { get => GetNode<ExitButton>("VBoxContainer/ExitButton"); }
        public HSlider HSlider { get => GetNode<HSlider>("VBoxContainer/Spacer/Control/HSlider"); }

        public override void _Ready()
        {
            base._Ready();
            Entry1.ColorChanged += (color) => OnNewColor(color, null);
            Entry2.ColorChanged += (color) => OnNewColor(null, color);
            Entry1.ColorRemoved += () => OnNewColor(null, null);
            Entry2.ColorRemoved += () => OnNewColor(null, null);
            HSlider.ValueChanged += (_) => OnNewColor(null, null);

            if (this.IsRunningScene())
            {
                Entry1.SetColor(new(0, 0, 1));
                Entry2.SetColor(new(0, 1, 0));
            }
        }

        private void OnNewColor(Color? color1, Color? color2)
        {
            Color? entry1Color = color1 ?? Entry1.Color;
            Color? entry2Color = color2 ?? Entry2.Color;
            if (entry1Color == null || entry2Color == null)
            {
                Exit.SetColor(null);
            }
            else
            {
                Color c1 = entry1Color.Value;
                Color c2 = entry2Color.Value;
                Color mixedColor = ColorOp.AlphaBlend(c1, c2, (float)HSlider.Value);
                Exit.SetColor(mixedColor);
            }
        }
    }
}