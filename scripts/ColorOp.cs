using Godot;
using System;

namespace Scripts
{
    static public class ColorOp
    {
        static public Color AlphaBlend(Color color1, Color color2, float alpha)
        {
            Color blendedColor = color1 * (1 - alpha) + color2 * alpha;
            return blendedColor;
        }
    }
}