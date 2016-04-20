using System;
using System.Collections.Generic;
using System.Linq;

namespace Neural.Core
{
    public class Perceptron : INeuron
    {
        private readonly Func<double, double> _inputNormalization;
        private readonly Func<double, double> _threshold;
        private readonly IList<double> _weights;

        public Perceptron(
            int inputCount, 
            Func<double, double> inputNormalization, 
            Func<double, double> threshold)
        {
            _inputNormalization = inputNormalization;
            _threshold = threshold;
            InputCount = inputCount;
            _weights = InitializeWeight(inputCount);
        }

        public double Compute(IEnumerable<double> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var inputVector = input.ToList();

            if (InputCount != inputVector.Count)
            {
                throw new ArgumentException("incorrect capacity of input arguments", nameof(input));
            }

            return (from index in Enumerable.Range(0, inputVector.Count)
                    select _weights[index] * _inputNormalization(inputVector[index]))
                .Aggregate(0.0, (accum, value) => accum + value, _threshold);
        }

        public void Correct(Func<double> correctDeltaFn, IEnumerable<double> input)
        {
            var inputVector = input.ToList();

            if (InputCount != inputVector.Count)
            {
                throw new ArgumentException("incorrect capacity of input arguments", nameof(input));
            }

            foreach (var index in Enumerable.Range(0, _weights.Count))
            {
                _weights[index] += correctDeltaFn() * inputVector[index];
            }
        }

        public int InputCount { get; private set; }

        public IEnumerable<double> Weights => _weights;

        private IList<double> InitializeWeight(int inputCount)
        {
            var random = new Random();
            var weights = new List<double>(inputCount);
            foreach (var index in Enumerable.Range(0, inputCount))
            {
                weights.Add(random.NextDouble());
            }
            return weights;
        }
    }
}
