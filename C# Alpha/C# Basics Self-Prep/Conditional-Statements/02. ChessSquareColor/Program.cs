namespace _02._ChessSquareColor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char label = char.Parse(Console.ReadLine());
            int rank = int.Parse(Console.ReadLine());

            bool isLight;

            if (rank % 2 != 0)
            {
                if (label % 2 != 0)
                {
                    isLight = false;
                }
                else
                {
                    isLight = true;
                }
            }
            else
            {
                if (label % 2 == 0)
                {
                    isLight = false;
                }
                else
                {
                    isLight = true;
                }
            }

            if (isLight)
            {
                Console.WriteLine("light");
            }
            else
            {
                Console.WriteLine("dark");
            }
        }
    }
}