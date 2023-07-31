using System.Text;

namespace _03._TitleSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternInput = Console.ReadLine();

            StringBuilder pattern = new StringBuilder();
            pattern.AppendLine(patternInput);

            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++) 
            {
                string line = Console.ReadLine();
                
                int lineLetterCount = 0;

                bool wasPatternLocated = false;

                List<int> indicesToRemove = new List<int>();

                for (int j = 0; j < pattern.Length; j++)
                {
                    if (pattern[j] == line[lineLetterCount])
                    {
                        lineLetterCount++;
                        indicesToRemove.Add(j);
                    }
                    if (lineLetterCount == line.Length)
                    {
                        wasPatternLocated = true;
                        break;
                    }
                }

                if (wasPatternLocated)
                {
                    int adjustIndexCounter = 0;

                    for (int k = 0; k < indicesToRemove.Count; k++)
                    {
                        pattern.Remove(indicesToRemove[k] - adjustIndexCounter, 1);
                        adjustIndexCounter++;
                    }

                    Console.WriteLine(pattern);
                }
                else
                {
                    Console.WriteLine("No such title found!");
                }
            }
        }
    }
}