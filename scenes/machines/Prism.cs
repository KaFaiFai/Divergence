using Godot;
using Godot.Collections;
using Scenes.Buttons;
using Scripts;
using System;

namespace Scenes.Machines
{
    public partial class Prism : Draggable
    {
        public EntryButton Entry { get => GetNode<EntryButton>("GridContainer/EntryButton"); }
        public ExitButton RedExit { get => GetNode<ExitButton>("GridContainer/RedExitButton"); }
        public ExitButton GreenExit { get => GetNode<ExitButton>("GridContainer/GreenExitButton"); }
        public ExitButton BlueExit { get => GetNode<ExitButton>("GridContainer/BlueExitButton"); }

        public override void _Ready()
        {
            base._Ready();
            Entry.ColorChanged += (color) => OnNewColor(color);
            Entry.ColorRemoved += () => OnNewColor(new(0, 0, 0));

            if (this.IsRunningScene())
            {
                Entry.SetColor(new(1, 1, 1));
            }
        }

        private void OnNewColor(Color color)
        {
            var (r, g, b) = ColorOp.Diverge(color);
            RedExit.SetColor(r);
            GreenExit.SetColor(g);
            BlueExit.SetColor(b);
        }
    }
}