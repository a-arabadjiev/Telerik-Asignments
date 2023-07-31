namespace _01._MilitaryTanks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine().ToLower();

            int xPosition = 0;
            int yPosition = 0;

            for (int i = 0; i < command.Length; i++) 
            {
                if (command[i] == 'r')
                {
                    xPosition++;
                }
                else if (command[i] == 'l') 
                {
                    xPosition--;
                }
                else if (command[i] == 'u')
                {
                    yPosition++;
                }
                else if (command[i] == 'd')
                {
                    yPosition--;
                }
            }

            Console.WriteLine($"({xPosition}, {yPosition})");
        }
    }
}