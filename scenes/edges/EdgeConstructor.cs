using Godot;
using Godot.Collections;
using Scenes.Buttons;
using System;
using System.Linq;

namespace Scenes.Edges
{
    public partial class EdgeConstructor : Node2D
    {
        [Signal] public delegate void CreatedEdgeEventHandler(Edge edge);

        public Array<ExitButton> AllExitButtons { get; set; }
        public Array<EntryButton> AllEntryButtons { get; set; }

        public ExitButton SelectedExit { get; private set; }
        public EntryButton SelectedEntry { get; private set; }

        public Line2D Line { get => GetNode<Line2D>("Line"); }

        private readonly PackedScene _edgeScene = GD.Load<PackedScene>("res://scenes/edges/Edge.tscn");

        public override void _Ready()
        {
            AllExitButtons = new(GetTree().GetNodesInGroup("exit_button").Select(e => (ExitButton)e));
            AllEntryButtons = new(GetTree().GetNodesInGroup("entry_button").Select(e => (EntryButton)e));

            foreach (ExitButton button in AllExitButtons)
            {
                button.Clicked += () => OnExitButtonClicked(button);
            }
            foreach (EntryButton button in AllEntryButtons)
            {
                button.Clicked += () => OnEntryButtonClicked(button);
            }
        }

        public override void _Process(double delta)
        {
            if (SelectedExit != null && SelectedEntry == null)
            {
                Vector2 mousePosition = GetGlobalMousePosition();
                Line.SetPointPosition(1, mousePosition);
            }
        }

        private void OnExitButtonClicked(ExitButton exit)
        {
            SelectedExit = exit;
            Line.Points = new Vector2[] { exit.GlobalPosition, exit.GlobalPosition };
            GD.Print($"[EdgeConstructor] exit at {exit.GlobalPosition}");
        }

        private void OnEntryButtonClicked(EntryButton entry)
        {
            if (SelectedExit == null) return;

            SelectedEntry = entry;
            GD.Print($"[EdgeConstructor] entry at {entry.GlobalPosition}");
            Edge newEdge = _edgeScene.Instantiate<Edge>();
            newEdge.Exit = SelectedExit;
            newEdge.Entry = SelectedEntry;
            EmitSignal(SignalName.CreatedEdge, newEdge);
            GD.Print("[EdgeConstructor] Creating new edge");

            SelectedExit = null;
            SelectedEntry = null;
            Line.Points = System.Array.Empty<Vector2>();
        }
    }
}