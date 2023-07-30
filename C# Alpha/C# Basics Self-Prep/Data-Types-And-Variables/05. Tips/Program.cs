namespace _05._Tips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bill = double.Parse(Console.ReadLine());

            double billWithTip = bill * 1.10;

            Console.WriteLine($"{billWithTip:F0}");
        }
    }
}