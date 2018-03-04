using System;
using System.Collections.Generic;
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

    public class CircumscribedCirclesFinder : ICalculator, IDisposable
    {
        private Rgb Color { get; set; }
        private Image<Rgb, byte> SourceImage { get; set; }
        private int Threshold { get; set; }
        private int NumberOfTriangles { get; set; }

        public CircumscribedCirclesFinder(Image<Rgb, byte> bitmap, CalculatorSettings settings)
        {
            Color = settings.Color.ToRgb();
            SourceImage = bitmap;
            Threshold = settings.Threshold;
            NumberOfTriangles = settings.NumberOfTriangles;
        }

        public List<ResultCircles> FindTriangleContour()
        {
            var imgUMat = Treshold().ToUMat();

            var contours = new VectorOfVectorOfPoint();

            CvInvoke.FindContours(imgUMat, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            var triangleList = TriangleProcessor.GetTriangles(contours);

            return GetBiggestCircles(triangleList);
        }

        private List<ResultCircles> GetBiggestCircles(List<PolygonCountour> polygonList)
        {
            return polygonList.OrderByDescending(x => x.Size)
                .Take(NumberOfTriangles)
                .Select((polygonCountour, index) => new ResultCircles
                {
                    Size = polygonCountour.Size,
                    Circle = TriangleProcessor.GetMiddle(polygonCountour.Countour),
                    Index = index + 1,
                    LabelPosition = TriangleProcessor.TriangleCenter(polygonCountour.Countour)
                }).ToList();
        }

        private Image<Gray, byte> Treshold()
        {
            var resultImage = new Image<Gray, byte>(SourceImage.Cols, SourceImage.Rows);

            for (var i = 0; i < SourceImage.Rows; i++)
            {
                for (var j = 0; j < SourceImage.Cols; j++)
                {
                    var diff = Math.Abs(SourceImage[i, j].Blue - Color.Blue) +
                               Math.Abs(SourceImage[i, j].Red - Color.Red) +
                               Math.Abs(SourceImage[i, j].Green - Color.Green);
                    resultImage[i, j] = diff <= Threshold ? new Gray(255) : new Gray(0);
                }
            }

            return resultImage.PyrUp().PyrDown();
        }

        public void Dispose()
        {
            SourceImage?.Dispose();
        }
    }
}