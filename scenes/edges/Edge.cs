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
            Exit.NewColor += (color) => OnNewColor(color);
            Exit.ClearedColor += () => OnNewColor(null);
            RemoveButton.Pressed += OnRemoveButtonPressed;
        }

        private void UpdateDisplay()
        {
            Vector2? exitPosition = Exit?.GlobalPosition;
            Vector2? entryPosition = Entry?.GlobalPosition;
            if (exitPosition != null && entryPosition != null)
            {
                Points = new Vector2[] { exitPosition.Value, entryPosition.Value };
                RemoveButtonControl.Position = (exitPosition.Value + entryPosition.Value) / 2;
            }
            else
            {
                Points = Array.Empty<Vector2>();
            }

            DefaultColor = Exit?.Color ?? new(1, 1, 1);
        }

        private void OnNewColor(Color? color)
        {
            if (!IsQueuedForDeletion())
            {
                DefaultColor = Exit?.Color ?? new(1, 1, 1);
                Entry.ReceiveColor(color);
            }
        }

        private void OnRemoveButtonPressed()
        {
            QueueFree();
            Entry.ReceiveColor(null);
        }
    }
}