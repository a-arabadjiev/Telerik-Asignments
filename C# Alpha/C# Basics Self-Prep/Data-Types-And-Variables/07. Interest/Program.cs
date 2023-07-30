namespace _07._Interest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sumDeposited = double.Parse(Console.ReadLine());

            Console.WriteLine($"{sumDeposited *= 1.05:F2}");
            Console.WriteLine($"{sumDeposited *= 1.05:F2}");
            Console.WriteLine($"{sumDeposited *= 1.05:F2}");
        }
    }
}