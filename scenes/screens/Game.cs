using Godot;
using Scenes.Levels;
using Scripts;
using System;

namespace Scenes.Screens
{
    public partial class Game : Control
    {
        public PackedScene LevelScene { get; set; }

        public Button MenuButton { get => GetNode<Button>("CanvasLayer/MenuButton"); }

        public override void _Ready()
        {
            SetLevel();
            MenuButton.Pressed += () => { ScreenTransition.Instance.ToMenu(); };
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