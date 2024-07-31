using Godot;
using Scenes.Buttons;
using System;

namespace Scenes.Edges
{
    public partial class Edge : Line2D
    {
        private ExitButton _exit;
        private EntryButton _entry;

        public ExitButton Exit { get => _exit; set { _exit = value; UpdateDisplay(); } }
        public EntryButton Entry { get => _entry; set { _entry = value; UpdateDisplay(); } }

        public Control RemoveButtonControl { get => GetNode<Control>("Control"); }
        public Button RemoveButton { get => GetNode<Button>("Control/RemoveButton"); }

        public override void _Ready()
        {
            Exit.NewColor += NewColor;
            Exit.ClearedColor += ClearedColor;
            RemoveButton.Pressed += OnRemoveButtonPressed;
        }

        public override void _Process(double delta)
        {
            base._Process(delta);
            UpdateDisplay(); // Exit and Entry can move at any time
        }

        public override void _ExitTree()
        {
            Exit.NewColor -= NewColor;
            Exit.ClearedColor -= ClearedColor;
        }

        private void UpdateDisplay()
        {
            Vector2? exitCenter = Exit?.GlobalCenter;
            Vector2? entryCenter = Entry?.GlobalCenter;
            if (exitCenter != null && entryCenter != null)
            {
                Points = new Vector2[] { exitCenter.Value, entryCenter.Value };
                RemoveButtonControl.Position = (exitCenter.Value + entryCenter.Value) / 2;
            }
            else
            {
                Points = Array.Empty<Vector2>();
            }

            DefaultColor = Exit?.Color ?? new(1, 1, 1);
        }

        private void NewColor(Color color) => OnNewColor(color);
        private void ClearedColor() => OnNewColor(null);

        private void OnNewColor(Color? color)
        {
            DefaultColor = Exit?.Color ?? new(1, 1, 1);
            Entry.ReceiveColor(color);
        }

        private void OnRemoveButtonPressed()
        {
            QueueFree();
            Entry.ReceiveColor(null);
        }
    }
}