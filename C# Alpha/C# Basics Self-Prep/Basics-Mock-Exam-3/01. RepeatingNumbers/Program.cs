namespace _01._RepeatingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int i = 0; i < arrayLength; i++) 
            {
                int currentNumber = int.Parse(Console.ReadLine());

                numbers.Add(currentNumber);
            }

            int mostRepeatedNumber = 0;
            int highestCounter = 0;

            List<int> numsAlreadyChecked = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentCounter = 1;

                int currentNumber = numbers[i];

                if (!numsAlreadyChecked.Any(n => n == currentNumber))
                {
                    for (int j = 0; j < numbers.Count; j++)
                    {
                        if (currentNumber == numbers[j])
                        {
                            currentCounter++;
                        }
                    }
                }

                numsAlreadyChecked.Add(currentNumber);

                if (currentCounter > highestCounter || currentCounter == highestCounter && currentNumber < mostRepeatedNumber) 
                {
                    mostRepeatedNumber = currentNumber;
                    highestCounter = currentCounter;
                }
            }

            Console.WriteLine(mostRepeatedNumber);
        }
    }
}