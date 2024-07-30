using Godot;
using Scenes.Buttons;
using System;

namespace Scenes.Entities
{
    public partial class Edge : Line2D
    {
        private ExitButton _exit;
        private EntryButton _entry;

        public ExitButton Exit { get => _exit; set { _exit = value; UpdateDisplay(); } }
        public EntryButton Entry { get => _entry; set { _entry = value; UpdateDisplay(); } }

        private void UpdateDisplay()
        {
            Vector2? exitPosition = Exit?.GlobalPosition;
            Vector2? entryPosition = Entry?.GlobalPosition;
            if (exitPosition != null && entryPosition != null) Points = new Vector2[] { exitPosition.Value, entryPosition.Value };
            else Points = Array.Empty<Vector2>();

            DefaultColor = Exit?.Color ?? new(1, 1, 1);
        }
    }
}