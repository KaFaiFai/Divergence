using Godot;
using Godot.Collections;
using Scenes.Machines;
using Scenes.Screens;
using Scripts;
using System;
using System.Linq;

namespace Scenes.Levels
{
    public partial class Level : Control
    {
        [Export] public PackedScene NextLevelScene { get; set; }

        public Array<Goal> Goals { get => this.GetChildren<Goal>(); }

        public override void _Ready()
        {
            foreach (var goal in Goals) goal.Colored += () => OnGoalColored(goal);
        }

        private void OnGoalColored(Goal goal)
        {
            bool hasWon = Goals.All(g => g.IsCorrect());
            GD.Print($"Level Won? {hasWon}");
            if (hasWon)
            {
                if (NextLevelScene != null)
                {
                    ScreenTransition.Instance.ChangeLevel(NextLevelScene);
                }
            }
        }
    }
}