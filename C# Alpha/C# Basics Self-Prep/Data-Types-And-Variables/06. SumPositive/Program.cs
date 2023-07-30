namespace _06._SumPositive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = n * (n + 1) / 2;

            Console.WriteLine(sum);
        }
    }
}