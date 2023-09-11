namespace _01._PrimeTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int currentNumber = 1; currentNumber <= n; currentNumber++)
            {
                bool isPrime = IsNumberPrime(currentNumber);

                if (isPrime)
                {
                    for (int j = 1; j <= currentNumber; j++)
                    {
                        isPrime = IsNumberPrime(j);
                        
                        if (isPrime)
                        {
                            Console.Write("1");
                        }
                        else 
                        {
                            Console.Write("0");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        private static bool IsNumberPrime(int currentNumber)
        {
            if (currentNumber == 1)
            {
                return true;
            }
            else if (currentNumber == 2)
            {
                return true;
            }

            for (int j = 2; j <= currentNumber - 1; j++)
            {
                if (currentNumber % j == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}