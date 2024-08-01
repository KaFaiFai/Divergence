using Godot;
using System;

namespace Scripts
{
    /// <summary>
    /// Implementation of most common color operations.
    /// Reference: <see href="https://www.codeproject.com/Articles/1202772/Color-Topics-for-Programmers"></see>
    /// 
    /// <para>
    /// All input colors and all output colors should be in sRGB space.
    /// </para>
    /// 
    /// </summary>
    static public class ColorOp
    {
        /// <summary>
        /// Custom operation that defines how color diverge through prism
        /// </summary>
        static public (Color?, Color?, Color?) Diverge(Color colorValue)
        {
            Color color = colorValue.SrgbToLinear();
            Color? r = color.R == 0 ? null : new(color.R, color.R / 10, color.R / 10);
            Color? g = color.G == 0 ? null : new(color.G / 10, color.G, color.G / 10);
            Color? b = color.B == 0 ? null : new(color.B / 10, color.B / 10, color.B);
            r = r?.LinearToSrgb();
            g = g?.LinearToSrgb();
            b = b?.LinearToSrgb();
            return (r, g, b);
        }

        static public Color AlphaBlend(Color color1, Color color2, float alpha)
        {
            Color blendedColor = color1.SrgbToLinear() * (1 - alpha) + color2.SrgbToLinear() * alpha;
            blendedColor = blendedColor.LinearToSrgb();
            return blendedColor;
        }
    }
}