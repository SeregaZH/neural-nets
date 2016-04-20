using System;
using System.Collections.Generic;

namespace Neural.Core
{
    public interface INeuron
    {
        double Compute(IEnumerable<double> input);

        void Correct(Func<double> correctDeltaFn, IEnumerable<double> input);

        int InputCount { get; }

        IEnumerable<double> Weights { get; }
    }
}
