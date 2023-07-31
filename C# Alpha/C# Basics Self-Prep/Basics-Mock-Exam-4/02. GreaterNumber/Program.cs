namespace _02._GreaterNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            List<int> finalArangement = new List<int>();

            List<int> numbersAlreadyChecked = new List<int>();

            for (int i = 0; i < firstArray.Length; i++)
            {
                int currentNumber = firstArray[i];

                if (!numbersAlreadyChecked.Contains(currentNumber))
                {
                    for (int j = 0; j < secondArray.Length; j++)
                    {
                        if (secondArray[j] == currentNumber)
                        {
                            // Check if outside of bounds
                            if (secondArray.Length == j + 1)
                            {
                                finalArangement.Add(-1);
                            }
                            else
                            {
                                int greaterNumber = currentNumber;

                                for (int k = j + 1; k < secondArray.Length; k++)
                                {
                                    int numberToRight = secondArray[k];

                                    if (greaterNumber < numberToRight)
                                    {
                                        greaterNumber = numberToRight;
                                        break;
                                    }
                                }

                                if (greaterNumber <= currentNumber)
                                {
                                    finalArangement.Add(-1);
                                }
                                else
                                {
                                    finalArangement.Add(greaterNumber);
                                }
                            }
                        }
                    }
                }

                numbersAlreadyChecked.Add(currentNumber);
            }

            string output = string.Join(",", finalArangement);

            Console.WriteLine(output);
        }
    }
}