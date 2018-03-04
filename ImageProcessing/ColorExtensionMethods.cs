using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;

namespace ImageProcessing
{
    public static class ColorExtensionMethods
    {
        public static Color InvertColor(this Color color) => Color.FromArgb(255 - color.R,
            255 - color.G, 255 - color.B);

        public static Rgb ToRgb(this Color color) => new Rgb(color.R, color.G, color.B);
    }
}
