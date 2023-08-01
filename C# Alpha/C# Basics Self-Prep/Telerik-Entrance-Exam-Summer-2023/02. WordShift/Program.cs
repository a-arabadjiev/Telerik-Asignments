using System.Text;

namespace _02._WordShift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputWords = Console.ReadLine().Split(' ').ToArray();

            StringBuilder output = new StringBuilder();
            output.Append(inputWords[0] + " ");

            for (int i = 1; i < inputWords.Length; i++)
            {
                string previousWord = inputWords[i - 1];
                string currentWord = inputWords[i];

                for (int j = 0; j < currentWord.Length; j++)
                {
                    int newSymbolNumber = 0;

                    if (char.IsLower(currentWord[j]))
                    {
                        newSymbolNumber = currentWord[j] + previousWord.Length;

                        while (newSymbolNumber >= 123)
                        {
                            int overBy = newSymbolNumber - 122;
                            newSymbolNumber = 96 + overBy;
                        }

                        output.Append((char)newSymbolNumber);
                    }

                    else if  (char.IsUpper(currentWord[j]))
                    {
                        newSymbolNumber = currentWord[j] + previousWord.Length;

                        while (newSymbolNumber >= 91)
                        {
                            int overBy = newSymbolNumber - 90;
                            newSymbolNumber = 64 + overBy;
                        }

                        output.Append((char)newSymbolNumber);
                    }
                }

                output.Append(" ");
            }

            Console.WriteLine(output);
        }
    }
}