namespace SoftwareDesignPatterns.Behavioral_patterns.Strategy
{
    //Strategy 2: Plus
    public class Plus : ICalculate
    {
        public int Calculate(int value1, int value2)
        {
            return value1 + value2;
        }
    }
}
