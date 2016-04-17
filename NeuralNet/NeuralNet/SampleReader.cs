using System;
using System.Collections.Generic;
using System.IO;

namespace NeuralNet
{
    public static class SampleReader
    {
        public static IEnumerable<SimpleSampleRecord> ReadSample()
        {
            using (var stream = new FileStream(Environment.CurrentDirectory + "\\Sampels\\SimpleFunctionSampel.txt", FileMode.Open))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var splittedString = line.Split('\t');
                        yield return new SimpleSampleRecord(double.Parse(splittedString[0]),
                            double.Parse(splittedString[1]),
                            double.Parse(splittedString[2]),
                            int.Parse(splittedString[3]));
                    }
                }
            }
        }
    }
}
