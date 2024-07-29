using Godot;
using System;

namespace Scripts
{
    public partial class GlobalEvents : RefCounted
    {
        [Signal] public delegate void LevelWonEventHandler();

        static public GlobalEvents Instance { get; private set; } = new();

        private GlobalEvents()
        {
            LevelWon += () => GD.Print("LevelWon");
        }
    }
}