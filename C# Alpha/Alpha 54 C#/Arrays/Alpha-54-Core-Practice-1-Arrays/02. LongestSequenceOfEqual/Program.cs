namespace _02._LongestSequenceOfEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++) 
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int previousNumber = numbers[0];

            int currentSequence = 1;
            int maximumSequence = 1;

            for (int i = 1; i < n; i++) 
            {
                if (numbers[i] == previousNumber)
                {
                    currentSequence++;
                }
                else
                {
                    currentSequence = 1;
                }

                if (currentSequence > maximumSequence) 
                {
                    maximumSequence = currentSequence;
                }

                previousNumber = numbers[i];
            }

            Console.WriteLine(maximumSequence);
        }
    }
}