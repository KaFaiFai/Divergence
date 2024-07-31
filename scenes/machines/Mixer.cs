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

        public override void _Ready()
        {
            base._Ready();
            Entry1.ChangedColor += (color) => OnNewColor(color, null);
            Entry2.ChangedColor += (color) => OnNewColor(null, color);
            Entry1.RemovedColor += () => OnNewColor(null, null);
            Entry2.RemovedColor += () => OnNewColor(null, null);

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
                Color mixedColor = new(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B);
                Exit.SetColor(mixedColor);
            }
        }
    }
}