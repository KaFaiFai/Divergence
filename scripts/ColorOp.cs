using Godot;
using System;

namespace Scripts
{
    /// <summary>
    /// Implementation of most common color operations.
    /// Reference: <see href="https://www.codeproject.com/Articles/1202772/Color-Topics-for-Programmers"></see>
    /// </summary>
    static public class ColorOp
    {
        /// <summary>
        /// Custom operation that defines how color diverge through prism
        /// </summary>
        static public (Color?, Color?, Color?) Diverge(Color color)
        {
            Color? r = color.R == 0 ? null : new(color.R, color.R / 3, color.R / 3);
            Color? g = color.G == 0 ? null : new(color.G / 3, color.G, color.G / 3);
            Color? b = color.B == 0 ? null : new(color.B / 3, color.B / 3, color.B);
            return (r, g, b);
        }

        static public Color AlphaBlend(Color color1, Color color2, float alpha)
        {
            Color blendedColor = color1 * (1 - alpha) + color2 * alpha;
            return blendedColor;
        }
    }
}