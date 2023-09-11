namespace _01._LongestIncreasingSequence
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> sequence = new List<int>();

            int maxSequence = 0;

            int previousNumber = 0;

            for (int i = 0; i < n; i++) 
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (i != 0)
                {
                    if (currentNumber > previousNumber)
                    {
                        sequence.Add(currentNumber);
                    }
                    else
                    {
                        if (maxSequence < sequence.Count)
                        {
                            maxSequence = sequence.Count;
                        }

                        sequence.Clear();

                    }
                }
                if (sequence.Count == 0)
                {
                    sequence.Add(currentNumber);
                }

                previousNumber = currentNumber;
            }

            Console.WriteLine(maxSequence);
        }
    }
}