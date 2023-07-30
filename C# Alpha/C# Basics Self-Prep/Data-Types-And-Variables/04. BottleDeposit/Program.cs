namespace BottleDeposit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double halfLiterBottleDeposit = 0.1;
            double fullLiterBottleDeposit = 0.25;

            int halfLiterBottlesCount = int.Parse(Console.ReadLine());
            int fullLiterBottlesCount = int.Parse(Console.ReadLine());

            double sum = halfLiterBottleDeposit * halfLiterBottlesCount + fullLiterBottleDeposit * fullLiterBottlesCount;

            Console.WriteLine($"{sum:F2}");
        }
    }
}