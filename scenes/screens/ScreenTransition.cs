using Godot;
using System;

namespace Scenes.Screens
{
    public partial class ScreenTransition : CanvasLayer
    {

        static private ScreenTransition _instance;
        static public ScreenTransition Instance { get => _instance; }

        public ColorRect RainbowTransition { get => GetNode<ColorRect>("RainbowTransition"); }
        public AnimationPlayer AnimationPlayer { get => GetNode<AnimationPlayer>("AnimationPlayer"); }

        private readonly PackedScene _gameScene = GD.Load<PackedScene>("res://scenes/screens/Game.tscn");

        public override void _EnterTree()
        {
            GD.Print("ScreenTransition _EnterTree");
            _instance = this;
            Visible = false;
        }

        public override void _Ready()
        {
            RainbowTransition.Resized += OnRainbowTransitionResized;
        }

        public async void ChangeLevel(PackedScene levelScene)
        {
            GD.Print("ScreenTransition ChangeLevel");
            Visible = true;
            AnimationPlayer.Play("rainbow_in");
            await ToSignal(AnimationPlayer, AnimationPlayer.SignalName.AnimationFinished);

            Game game = _gameScene.Instantiate<Game>();
            game.LevelScene = levelScene;
            PackedScene gameWithLevel = new();
            gameWithLevel.Pack(game);
            GetTree().ChangeSceneToPacked(gameWithLevel);

            AnimationPlayer.PlayBackwards("rainbow_in");
            await ToSignal(AnimationPlayer, AnimationPlayer.SignalName.AnimationFinished);
            Visible = false;
        }

        private void OnRainbowTransitionResized()
        {
            RainbowTransition.Material.Set("shader_parameter/aspect_ratio", RainbowTransition.Size.X / RainbowTransition.Size.Y);
        }
    }
}