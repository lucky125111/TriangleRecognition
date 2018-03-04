using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ImageProcessing
{
    //public interface ITriangleProcessor
    //{
    //    CircleF GetMiddle(VectorOfPoint vertices);
    //    bool IsTriangle(VectorOfPoint contour, out VectorOfPoint poly);
    //    Point TriangleCenter(VectorOfPoint el);
    //}
    public static class TriangleProcessor
    {
        public static CircleF GetMiddle(VectorOfPoint vertices)
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

        public static bool IsTriangle(VectorOfPoint contour, out VectorOfPoint poly)
        {
            poly = new VectorOfPoint();

            //TODO opisac
            CvInvoke.ApproxPolyDP(contour, poly, 0.03 * CvInvoke.ArcLength(contour, true), true);

            if (poly.Size != 3)
                return false;

            return true;
        }

        public static Point TriangleCenter(VectorOfPoint el)
        {
            if (el.Size != 3)
                throw new Exception();

            return new Point((int)((el[0].X + el[1].X + el[2].X) * 1.0 / 3)
                , (int)((el[0].Y + el[1].Y + el[2].Y) * 1.0 / 3));
        }

        public static List<PolygonCountour> GetTriangles(VectorOfVectorOfPoint contours)
        {
            var triangleList = new List<PolygonCountour>();

            for (var i = 0; i < contours.Size; i++)
            {
                VectorOfPoint approxPoly;
                if (!IsTriangle(contours[i], out approxPoly))
                    continue;

                triangleList.Add(new PolygonCountour
                {
                    Size = CvInvoke.ContourArea(approxPoly),
                    Countour = approxPoly
                });
            }
            return triangleList;
        }
    }
}