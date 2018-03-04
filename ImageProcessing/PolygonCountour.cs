using Emgu.CV.Util;

namespace ImageProcessing
{
    /// <summary>
    /// Struktura przetrzymujaca informacje o wielokacie i jego powierzchni
    /// </summary>
    public struct PolygonCountour
    {
        public double Size;
        public VectorOfPoint Countour;
    }
}