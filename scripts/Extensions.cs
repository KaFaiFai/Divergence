using Godot;
using Godot.Collections;
using System;

namespace Scripts
{
    static public class NodeExtensions
    {
        static public Array<T> GetChildren<[MustBeVariant] T>(this Node node, bool includeInternal = false)
            where T : Node
        {
            Array<T> children = new();
            foreach (var n in node.GetChildren(includeInternal: includeInternal))
            {
                if (n is T t) children.Add(t);
            }
            return children;
        }

        /// <summary>
        /// Detect if the current node is the running scene. Used only for debugging
        /// </summary>
        static public bool IsRunningScene(this Node node)
        {
            return node.GetTree().CurrentScene.Name == node.Name;
        }
    }
}
