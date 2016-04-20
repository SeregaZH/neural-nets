using System.Collections.Generic;

namespace Neural.Core
{
    public sealed class Sample
    {
        public Sample(IEnumerable<double> inputVector, double expectedResult)
        {
            InputVector = inputVector;
            ExpectedResult = expectedResult;
        }

        public IEnumerable<double> InputVector { get; private set; }

        public double ExpectedResult { get; private set; }
    }
}
