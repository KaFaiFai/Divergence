using Godot;
using Godot.Collections;
using Scenes.Buttons;
using Scripts;
using System;
using System.Linq;

namespace Scenes.Edges
{
    public partial class EdgesManager : Node
    {
        public Array<EdgeConstructor> EdgeConstructors { get; set; }
        public Array<Edge> AllEdges { get => this.GetChildren<Edge>(); }

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            EdgeConstructors = new(GetTree().GetNodesInGroup("edge_constructor").Select(e => (EdgeConstructor)e));
            foreach (var item in EdgeConstructors) item.CreatedEdge += OnCreatedEdge;

        }

        private void OnCreatedEdge(Edge edge)
        {
            GD.Print("EdgesManager OnCreatedEdge");
            AddChild(edge);
            edge.Entry.SetColor(edge.Exit.Color);
        }
    }
}