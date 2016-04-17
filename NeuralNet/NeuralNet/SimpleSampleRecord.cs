namespace NeuralNet
{
    public class SimpleSampleRecord
    {
        public SimpleSampleRecord(double pointX, double pointY, double pointZ, int result)
        {
            PointX = pointX;
            PointY = pointY;
            PointZ = pointZ;
            ExpectedResult = result;
        }

        public double PointX { get; private set; }

        public double PointY { get; private set; }

        public double PointZ { get; private set; }

        public int ExpectedResult { get; private set; }
    }
}
