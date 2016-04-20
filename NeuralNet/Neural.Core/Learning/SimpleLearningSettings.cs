namespace Neural.Core.Learning
{
    public sealed class SimpleLearningSettings
    {
        public SimpleLearningSettings(double learningSpeed)
        {
            LearningSpeed = learningSpeed;
        }

        public double LearningSpeed { get; private set; }
    }
}
