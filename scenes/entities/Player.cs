using Godot;
using Scripts;
using System;

namespace Scenes.Entities
{
    public partial class Player : Node2D
    {
        private Color _color;

        [Export] public float Speed { get; set; }
        public Color Color { get => _color; private set { _color = value; UpdateDisplay(); } }

        public Area2D Area { get => GetNode<Area2D>("Area2D"); }

        static public Vector2 GetInput() => Input.GetVector("left", "right", "up", "down");

        public override void _Ready()
        {
            Color = Colors.Black;
            Area.AreaEntered += OnAreaEntered;
        }

        public override void _Process(double delta)
        {
        }

        public override void _PhysicsProcess(double delta)
        {
            Vector2 input = GetInput();
            Position += input * Speed;
        }

        private void OnAreaEntered(Area2D area)
        {
            Node parent = area.GetParent();
            if (parent is ColorPortal colorPortal)
            {
                MeetColor(colorPortal.Color);
                parent.QueueFree();
            }
            else if (parent is Goal goal)
            {
                if (Color == goal.Color) GlobalEvents.Instance.EmitSignal(GlobalEvents.SignalName.LevelWon);
            }
        }

        private void MeetColor(Color color)
        {
            Color = color;
        }

        private void UpdateDisplay()
        {
            Modulate = Color;
        }
    }
}