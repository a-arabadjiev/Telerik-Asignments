
using System.Text;

namespace _03._AloneNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int target = int.Parse(Console.ReadLine());

            List<int> remadeArray = inputArray.ToList();

            for (int i = 1; i < inputArray.Length - 1; i++) 
            {
                int currentNum = inputArray[i];

                int leftNum = inputArray[i - 1];
                int rightNum = inputArray[i + 1];

                if (currentNum == target)
                {
                    if (leftNum != target && rightNum != target)
                    {
                        if (leftNum >= rightNum)
                        {
                            remadeArray[i] = leftNum;
                        }
                        else
                        {
                            remadeArray[i] = rightNum;
                        }
                    }
                }
            }

            StringBuilder output = new StringBuilder();

            foreach (var num in remadeArray)
            {
                output.Append($"{num}, ");
            }

            output.Remove(output.Length - 2, 2);

            Console.WriteLine($"[{output}]");
        }
    }
}