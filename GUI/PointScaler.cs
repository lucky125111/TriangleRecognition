using System.Drawing;

namespace GUI
{
    public class PointScaler
    {
        public Size SourceSize;
        public Size TargetSize;

        public PointScaler(Size sourceSize, Size targetSize)
        {
            SourceSize = sourceSize;
            TargetSize = targetSize;
        }
        public Point ScaleToPictureBox(PointF p)
        {
            return new Point((int) (p.X * TargetSize.Width / SourceSize.Width), (int)(p.Y * TargetSize.Height / SourceSize.Height));            
        }
        public Point ScaleToSource(Size imageBoxSize, PointF p)
        {
            return new Point((int)(p.X * SourceSize.Width/ imageBoxSize.Width), (int)(p.Y * SourceSize.Height / imageBoxSize.Height));
        }
    }
}