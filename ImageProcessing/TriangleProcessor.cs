using System;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ImageProcessing
{
    public interface ITriangleProcessor
    {
        CircleF GetMiddle(VectorOfPoint vertices);
    }
    public class TriangleProcessor : ITriangleProcessor
    {
        public CircleF GetMiddle(VectorOfPoint vertices)
        {
            var ax = vertices[0].X;
            var ay = vertices[0].Y;

            var bx = vertices[1].X;
            var by = vertices[1].Y;

            var cx = vertices[2].X;
            var cy = vertices[2].Y;
            
            var d = 2.0 * (ax * (by - cy) + bx * ( cy - ay) + cx * ( ay - by));

            var ux = 1.0 / d * ((ax*ax+ay*ay)*(by-cy)+(bx*bx+by*by)*(cy - ay)+(cx*cx+cy*cy)*(ay -by));
            var uy = 1.0 / d * ((ax*ax+ay*ay)*(cx-bx)+(bx*bx+by*by)*(ax - cx)+(cx*cx+cy*cy)*(bx -ax));

            var r = Math.Sqrt(Math.Pow(ux - ax, 2) + Math.Pow(uy - ay, 2));

            return new CircleF(new PointF((float)ux, (float)uy), (float)r);
        }
    }
}