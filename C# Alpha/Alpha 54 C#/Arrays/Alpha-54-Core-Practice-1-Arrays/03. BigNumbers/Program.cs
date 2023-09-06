namespace _03._BigNumbers
{
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArraySizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            int[] firstArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] smallestArray = firstArray.Length <= secondArray.Length ? firstArray : secondArray;
            int[] largestArray = firstArray.Length >= secondArray.Length ? firstArray : secondArray;

            StringBuilder output = new StringBuilder();

            int leftoverFromSum = 0;

            for (int i = 0; i < smallestArray.Length; i++)
            {
                int firstArrayNum = firstArray[i];
                int secondArrayNum = secondArray[i];

                int sum = firstArrayNum + secondArrayNum + leftoverFromSum;

                if (sum > 9) 
                {
                    leftoverFromSum = 1;
                    sum -= 10;
                }
                else
                {
                    leftoverFromSum = 0;
                }

                output.Append($"{sum} ");
            }

            if (inputArraySizes[0] != inputArraySizes[1])
            {
                for (int i = smallestArray.Length; i < largestArray.Length; i++)
                {
                    int sum = largestArray[i] + leftoverFromSum;

                    if (sum > 9)
                    {
                        leftoverFromSum = 1;
                        sum -= 10;
                    }
                    else
                    {
                        leftoverFromSum = 0;
                    }

                    output.Append($"{sum} ");
                }
            }

            if (leftoverFromSum == 1)
            {
                output.Append($"{leftoverFromSum}");
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }
    }
}