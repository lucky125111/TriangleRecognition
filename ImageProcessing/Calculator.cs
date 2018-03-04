using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ImageProcessing
{
    public interface ICalculator
    {
        List<ResultCircles> FindTriangleContour();
    }

    public class Calculator : ICalculator, IDisposable
    {
        public Calculator(Color c, Image<Rgb, byte> bitmap, int threshold, int numberOfTriangles)
        {
            Color = new Rgb(c);
            SourceImage = bitmap;
            Threshold = threshold;
            Triangle = new TriangleProcessor();
            NumberOfTriangles = numberOfTriangles;
        }

        private Rgb Color { get; set; }
        private Image<Rgb, byte> SourceImage { get; set; }
        private int Threshold { get; set; }
        private ITriangleProcessor Triangle { get; set; }
        private int NumberOfTriangles { get; set; }

        public List<ResultCircles> FindTriangleContour()
        {
            var img = Treshold();

            var canny = img.ToUMat();

            var contours = new VectorOfVectorOfPoint();

            //TODO opisac
            CvInvoke.FindContours(canny, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            var l = new List<PolygonSize>();

            for (var i = 0; i < contours.Size; i++)
            {
                VectorOfPoint poly;
                if (!IsTriangle(contours[i], out poly))
                    continue;

                l.Add(new PolygonSize {Size = CvInvoke.ContourArea(contours[i], false), Countour = poly});
            }
            
            return l.OrderByDescending(x => x.Size)
                .Take(NumberOfTriangles)
                .Select((el, index) => new ResultCircles
                {
                    Size = el.Size,
                    Circle = Triangle.GetMiddle(el.Countour),
                    Index = index + 1,
                    LabelPosition = TriangleCenter(el.Countour)
                })
                .ToList();
        }

        private Image<Gray, byte> Treshold()
        {
            //TODO opisac
            var img = SourceImage; 

            var res = new Image<Gray, byte>(SourceImage.Cols, SourceImage.Rows);

            for (var i = 0; i < SourceImage.Rows; i++)
            for (var j = 0; j < SourceImage.Cols; j++)
            {
                var diff = Math.Abs(img[i, j].Blue - Color.Blue) +
                           Math.Abs(img[i, j].Red - Color.Red) +
                           Math.Abs(img[i, j].Green - Color.Green);
                if (diff <= Threshold)
                    res[i, j] = new Gray(255);
                else
                    res[i, j] = new Gray(0);
            }

            //TODO opisac
            var test = res.PyrUp().PyrDown();
            return test;
        }

        private bool IsTriangle(VectorOfPoint contour, out VectorOfPoint poly)
        {
            poly = new VectorOfPoint();

            //TODO opisac
            CvInvoke.ApproxPolyDP(contour, poly, 0.03 * CvInvoke.ArcLength(contour, true), true);

            if (poly.Size != 3)
                return false;

            return true;
        }

        private Point TriangleCenter(VectorOfPoint el)
        {
            if (el.Size != 3)
                throw new Exception();

            return new Point((int) ((el[0].X + el[1].X + el[2].X) * 1.0 / 3)
                , (int) ((el[0].Y + el[1].Y + el[2].Y) * 1.0 / 3));
        }

        public void Dispose()
        {
            SourceImage?.Dispose();
        }
    }
}