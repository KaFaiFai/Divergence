using Godot;
using Godot.Collections;
using Scripts;
using System;
using System.Linq;

namespace Scenes.Edges
{
    public partial class EdgesManager : Node
    {
        public EdgeConstructor EdgeConstructor { get; set; }
        public Array<Edge> AllEdges { get => this.GetChildren<Edge>(); }

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            EdgeConstructor = (EdgeConstructor)GetTree().GetFirstNodeInGroup("edge_constructor");
            EdgeConstructor.CreatedEdge += OnCreatedEdge;
        }

        private void OnCreatedEdge(Edge edge)
        {
            AddChild(edge);
            edge.Entry.SetColor(edge.Exit.Color);
        }
    }
}