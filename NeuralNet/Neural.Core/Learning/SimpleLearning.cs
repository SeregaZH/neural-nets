using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neural.Core.Learning
{
    public class SimpleLearning : ILearningAlgorithm
    {
        private readonly PerceptronSettings _settings;
        private readonly SimpleLearningSettings _learningSettings;
        private readonly ILog _logger;
 
        public SimpleLearning(
            PerceptronSettings settings,
            SimpleLearningSettings learningSettings,
            ILog logger)
        {
            _settings = settings;
            _learningSettings = learningSettings;
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
            do
            {
                errorCount = 0;
                foreach (var sample in samples)
                {
                    double result = 0;
                    result = neuron.Compute(sample.InputVector);
                    if (result != sample.ExpectedResult) errorCount++;

                    while (result != sample.ExpectedResult)
                    {
                        if (result > sample.ExpectedResult) neuron.Correct(() => -_learningSettings.LearningSpeed, sample.InputVector);
                        else if (result < sample.ExpectedResult) neuron.Correct(() => _learningSettings.LearningSpeed, sample.InputVector);
                        result = neuron.Compute(sample.InputVector);
                    }
                }

                _logger.Info(string.Format("Error count:{0}", errorCount));

            } while (errorCount > Math.Ceiling(sampleCount * _settings.ErrorPercent));           

            return neuron;
        }
    }
}
