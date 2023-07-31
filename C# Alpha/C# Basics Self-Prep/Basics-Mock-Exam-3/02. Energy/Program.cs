namespace _02._Energy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(int.Parse(input[i].ToString()));
            }

            int oddSum = numbers.Where(x => x % 2 != 0).Sum();
            int evenSum = numbers.Where(x => x % 2 == 0).Sum();

            if (evenSum > oddSum)
            {
                Console.WriteLine($"{evenSum} energy drinks");
            }
            else if (oddSum > evenSum)
            {
                Console.WriteLine($"{oddSum} cups of coffee");
            }
            else if (evenSum == oddSum) 
            {
                Console.WriteLine($"{evenSum} of both");
            }
        }
    }
}