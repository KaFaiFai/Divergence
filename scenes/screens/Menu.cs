using Godot;
using Godot.Collections;
using System;
using System.Linq;

namespace Scenes.Screens
{
    public partial class Menu : Control
    {
        static private readonly int _numLevels = 8;

        public GridContainer GridContainer { get => GetNode<GridContainer>("GridContainer"); }

        public override void _Ready()
        {
            foreach (var i in Enumerable.Range(0, _numLevels))
            {
                Button button = new() { Text = $"Level {i}" };
                button.Pressed += () =>
                {
                    PackedScene levelScene = GD.Load<PackedScene>($"res://scenes/levels/Level{i}.tscn");
                    ScreenTransition.Instance.ToLevel(levelScene);
                };
                GridContainer.AddChild(button);
            }
        }
    }
}