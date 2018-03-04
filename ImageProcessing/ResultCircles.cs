using System.Drawing;
using Emgu.CV.Structure;

namespace ImageProcessing
{
    public struct ResultCircles
    {
        public double Size;
        public int Index;
        public CircleF Circle;
        public Point LabelPosition;
    }
}