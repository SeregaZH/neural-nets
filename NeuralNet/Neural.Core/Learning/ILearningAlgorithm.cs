using System.Collections.Generic;

namespace Neural.Core.Learning
{
    public interface ILearningAlgorithm
    {
        INeuron Learn(IEnumerable<Sample> samples);
    }
}
