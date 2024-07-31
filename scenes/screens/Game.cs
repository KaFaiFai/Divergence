using Godot;
using Scenes.Levels;
using Scripts;
using System;

namespace Scenes.Screens
{
    public partial class Game : Control
    {
        [Export] public PackedScene LevelScene { get; set; }

        public override void _Ready()
        {
            SetLevel();
        }

        private void SetLevel()
        {
            if (LevelScene != null)
            {
                foreach (Level l in this.GetChildren<Level>()) l.QueueFree();
                Level level = LevelScene.Instantiate<Level>();
                AddChild(level);
            }
        }
    }
}