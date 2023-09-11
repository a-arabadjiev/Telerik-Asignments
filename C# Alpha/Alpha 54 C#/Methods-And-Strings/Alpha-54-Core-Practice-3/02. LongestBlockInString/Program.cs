namespace _02._LongestBlockInString
{
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            List<string> allStrings = new List<string>();

            char previousChar = 'a';

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (i != 0)
                {
                    if (currentChar == previousChar)
                    {
                        sb.Append(currentChar);
                    }
                    else
                    {
                        allStrings.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                if (sb.Length == 0)
                {
                    sb.Append(currentChar);
                }

                previousChar = currentChar;

                if (i + 1 == input.Length)
                {
                    allStrings.Add(sb.ToString());
                }
            }

            if (allStrings.Count > 0)
            {
                int longestLength = allStrings.Max(x => x.Length);
                string longestBlock = allStrings.First(x => x.Length == longestLength);

                Console.WriteLine(longestBlock);
            }
            else
            {
                Console.WriteLine(sb.ToString());
            }
        }
    }
}