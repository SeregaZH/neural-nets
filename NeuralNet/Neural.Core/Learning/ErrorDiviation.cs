using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural.Core.Learning
{
    public class ErrorDiviation : ILearningAlgorithm
    {
        private readonly PerceptronSettings _settings;
        private readonly ILog _logger;

        public ErrorDiviation(
            PerceptronSettings settings,
            ILog logger)
        {
            _settings = settings;
            _logger = logger;
        }

        public INeuron Learn(IEnumerable<Sample> samples)
        {
            var neuron = new Perceptron(
                _settings.InputCount,
                _settings.InputNormalization,
                _settings.Threshold);

            var sampleCount = samples.Count();

            int errorCount = 0;

            foreach (var sample in samples)
            {
                var result = neuron.Compute(sample.InputVector);
                if (result != sample.ExpectedResult) errorCount++;
            }

            return neuron;
        }
    }
}
