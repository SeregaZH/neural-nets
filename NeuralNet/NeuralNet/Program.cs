using log4net;
using Neural.Core;
using Neural.Core.Learning;
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
            var loggerRepo = LoggerConfigurator.Configure();
            var simpleLearn = new SimpleLearning(
                new PerceptronSettings(3, x => x , t => Math.Round(1/(1 + Math.Pow(Math.E, -t)), MidpointRounding.ToEven), 0.01),
                LogManager.GetLogger("log"));
            var errorDiviationLearn = new ErrorDiviation(new PerceptronSettings(3, x => x, t => Math.Round(1 / (1 + Math.Pow(Math.E, -t)), MidpointRounding.ToEven), 0.01), 
                LogManager.GetLogger("log"));
            
            var samples = SampleReader.ReadSample();

            var neuron = simpleLearn.Learn(
                samples.Select(
                    x => new Sample(new double[] { x.PointX, x.PointY, x.PointZ }, x.ExpectedResult)));

            var neuron2 = errorDiviationLearn.Learn(samples.Select(
                    x => new Sample(new double[] { x.PointX, x.PointY, x.PointZ }, x.ExpectedResult)));

            var weights = neuron.Weights.ToList();
            var weights2 = neuron2.Weights.ToList();
            Console.WriteLine("Simple: Wx:{0}, Wy:{1}, Wz:{2}", weights[0], weights[1], weights[2]);
            Console.WriteLine("Diviation: Wx:{0}, Wy:{1}, Wz:{2}", weights2[0], weights2[1], weights2[2]);
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
