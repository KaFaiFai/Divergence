using Godot;
using Scenes.Buttons;
using Scripts;
using System;

namespace Scenes.Machines
{
    public partial class Goal : Draggable
    {
        [Signal] public delegate void ColoredEventHandler();

        [Export] public Color TargetColor { get; set; }

        static private readonly float _error = 0.10f;

        public EntryButton Entry { get => GetNode<EntryButton>("HBoxContainer/EntryButton"); }
        public Control Spacer { get => GetNode<Control>("HBoxContainer/Spacer"); }
        public Polygon2D FlagLogo { get => GetNode<Polygon2D>("HBoxContainer/Spacer/Control/FlagLogo"); }
        public Label ColorLabel { get => GetNode<Label>("ColorLabel"); }

        public override void _Ready()
        {
            base._Ready();
            Entry.ColorChanged += (color) =>
            {
                GD.Print($"Goal {color}");
                OnNewColor(color);
            };
            Entry.ColorRemoved += () => OnNewColor(null);
            FlagLogo.Color = TargetColor;

            Spacer.MouseEntered += () =>
            {
                ColorLabel.Visible = true;
                ColorLabel.Text = $"R: {TargetColor.R:F2}| G: {TargetColor.G:F2}| B: {TargetColor.B:F2}";
            };
            Spacer.MouseExited += () => { ColorLabel.Visible = false; };
            ColorLabel.Visible = false;

            if (this.IsRunningScene())
            {
                Entry.SetColor(new(1, 1, 1));
            }
        }

        public bool IsCorrect()
        {
            if (Entry.Color == null) return false;
            Color entryColor = Entry.Color.Value;
            Color colorDiff = entryColor - TargetColor;
            float diff = MathF.Abs(colorDiff.R) + MathF.Abs(colorDiff.G) + MathF.Abs(colorDiff.B);
            return diff < _error;
        }

        private void OnNewColor(Color? color)
        {
            EmitSignal(SignalName.Colored);
        }
    }
}
