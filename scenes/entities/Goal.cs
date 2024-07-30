using Godot;
using System;

namespace Scenes.Entities
{
    public partial class Goal : Control
    {
        [Signal] public delegate void ReceivedInputEventHandler(bool isCorrect);

        [Export] public Color TargetColor { get; set; }

        public ColorSource Input { get; private set; }

        public void ReceiveInput(ColorSource input)
        {
            Input = input;
            EmitSignal(SignalName.ReceivedInput, input?.Color == TargetColor);
        }
    }
}
