using Neural.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeuralNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //function 3x+2y-z  = 0
            const double LearningSpeed = 0.1;
            var neuron = new Perceptron(3, x => x*0.01, t => t >= 0 ? 1 : 0);
            var samples = SampleReader.ReadSample();

            int isError = 0;
            do
            {
                isError = 0;
                foreach (var sample in samples)
                {
                    double result = -1;
                    var inputVector = new double[] { sample.PointX, sample.PointY, sample.PointZ };
                    result = neuron.Compute(inputVector);
                    if (result != sample.ExpectedResult) isError++;

                    while (result != sample.ExpectedResult)
                    {
                        if (result > sample.ExpectedResult) neuron.Correct(LearningSpeed, -1, inputVector);
                        else if (result < sample.ExpectedResult) neuron.Correct(LearningSpeed, 1, inputVector);
                        result = neuron.Compute(new double[] { sample.PointX, sample.PointY, sample.PointZ });
                    }

                    Console.WriteLine("{0} {1} {2}", sample.PointX, sample.PointY, sample.PointZ);
                }

                Console.WriteLine(isError);

            } while (isError != 0);

            string inputString = string.Empty;
            do {
                inputString = Console.ReadLine();
                if (string.IsNullOrEmpty(inputString)) break;
                var inp = inputString.Split(' ');
                var result = neuron.Compute(new double[] { double.Parse(inp[0]), double.Parse(inp[1]), double.Parse(inp[2]) });
                Console.WriteLine(result);
            } while (true);
        }
    }
}
