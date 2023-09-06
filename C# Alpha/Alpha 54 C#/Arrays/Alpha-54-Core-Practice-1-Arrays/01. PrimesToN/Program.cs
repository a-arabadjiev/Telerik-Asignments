namespace _01._PrimesToN
{
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder primeNumbers = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = i;
                bool isPrime = true;

                if (currentNumber == 1 || currentNumber == 2)
                {
                    primeNumbers.Append($"{currentNumber} ");
                }
                else 
                {
                    for (int j = 2; j <= currentNumber - 1; j++)
                    {
                        if (currentNumber % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        primeNumbers.Append($"{currentNumber} ");
                    }
                }
            }

            Console.WriteLine(primeNumbers.ToString().TrimEnd());
        }
    }
}