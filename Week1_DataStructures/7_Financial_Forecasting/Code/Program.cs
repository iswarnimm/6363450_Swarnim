using System;

class Program
{
    // Recursive method to calculate future value
    public static double PredictFutureValue(double currentValue, double growthRate, int years)
    {
        // Base case: if 0 years left, return current value
        if (years == 0)
            return currentValue;

        // Recursive step: calculate value for remaining years
        return PredictFutureValue(currentValue * (1 + growthRate), growthRate, years - 1);
    }

    static void Main(string[] args)
    {
        // Initial values
        double currentValue = 10000;     // ₹10,000
        double growthRate = 0.10;        // 10% annual growth
        int years = 5;                   // Number of years to predict

        // Call the recursive method
        double futureValue = PredictFutureValue(currentValue, growthRate, years);

        // Print result
        Console.WriteLine($"Future value after {years} years: ₹{futureValue:F2}");
    }
}
