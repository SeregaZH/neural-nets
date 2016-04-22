using System;

namespace Neural.Core
{
    public sealed class PerceptronSettings
    {
        public PerceptronSettings(
            int inputCount,
            Func<double, double> inputNormalization,
            Func<double, double> threshold,
            double learningSpeed,
            double errorPercent = 0)
        {
            InputCount = inputCount;
            InputNormalization = inputNormalization;
            Threshold = threshold;
            LearningSpeed = learningSpeed;
            ErrorPercent = errorPercent;
        }

        public int InputCount { get; private set; }

        public Func<double, double> InputNormalization { get; private set; }

        public Func<double, double> Threshold { get; private set; }

        public double ErrorPercent { get; private set; }

        public double LearningSpeed { get; private set; }
    }
}
