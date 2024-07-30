using Godot;
using Godot.Collections;
using Scenes.Buttons;
using Scripts;
using System;

namespace Scenes.Machines
{
    public partial class Prism : Control
    {
        public EntryButton Entry { get => this.GetNode<EntryButton>("EntryButton"); }
        public ExitButton RedExit { get => this.GetNode<ExitButton>("RedExitButton"); }
        public ExitButton GreenExit { get => this.GetNode<ExitButton>("GreenExitButton"); }
        public ExitButton BlueExit { get => this.GetNode<ExitButton>("BlueExitButton"); }

        public override void _Ready()
        {
            Entry.ReceivedColor += (color) => OnNewColor(color);
            Entry.RemovedColor += () => OnNewColor(new(0, 0, 0));

            if (this.IsRunningScene())
            {
                Entry.ReceiveColor(new(1, 1, 1));
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