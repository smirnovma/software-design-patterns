namespace SoftwareDesignPatterns.Behavioral_patterns.Strategy
{
    //The client
    public class CalculateClient
    {
        public ICalculate Strategy { get; set; }

        public CalculateClient(ICalculate strategy)
        {
            Strategy = strategy;
        }

        //Executes the strategy
        public int Calculate(int value1, int value2)
        {
            return Strategy.Calculate(value1, value2);
        }
    }
}
