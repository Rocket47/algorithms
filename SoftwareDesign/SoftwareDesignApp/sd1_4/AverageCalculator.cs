namespace SoftwareDesign.sd1_4
{
    public class AverageCalculator
    {
        public static double CalculateAverage(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }
            
            long sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }
            
            return (double)sum / numbers.Length;
        }
    }
}