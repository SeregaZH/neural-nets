using System;

namespace Neural.Core
{
    public sealed class PerceptronSettings
    {
        public PerceptronSettings(
            int inputCount,
            Func<double, double> inputNormalization,
            Func<double, double> threshold)
        {
            InputCount = inputCount;
            InputNormalization = inputNormalization;
            Threshold = threshold;
        }

        public int InputCount { get; private set; }

        public Func<double, double> InputNormalization { get; private set; }

        public Func<double, double> Threshold { get; private set; }

        public double ErrorPercent { get; private set; }
    }
}
