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
            Entry.ChangedColor += (color) => OnNewColor(color);
            Entry.RemovedColor += () => OnNewColor(new(0, 0, 0));

            if (this.IsRunningScene())
            {
                Entry.SetColor(new(1, 1, 1));
            }
        }

        private void OnNewColor(Color color)
        {
            if (color.R == 0) RedExit.SetColor(null);
            else RedExit.SetColor(new(color.R, 0, 0));

            if (color.G == 0) GreenExit.SetColor(null);
            else GreenExit.SetColor(new(0, color.G, 0));

            if (color.B == 0) BlueExit.SetColor(null);
            else BlueExit.SetColor(new(0, 0, color.B));
        }
    }
}