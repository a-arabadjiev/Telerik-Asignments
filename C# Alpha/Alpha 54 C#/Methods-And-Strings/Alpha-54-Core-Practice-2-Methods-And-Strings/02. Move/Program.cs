namespace _02._Move
{
    internal class Program
    {
        private static int currentPoint = 0;
        private static int forwardSum = 0;
        private static int backwardsSum = 0;

        static void Main(string[] args)
        {
            int startingPoint = int.Parse(Console.ReadLine());
            currentPoint = startingPoint;

            int[] numbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            string[] commands = Console.ReadLine().Split().ToArray();

            while (commands[0].ToLower() != "exit")
            {
                InitiateCommand(commands, numbers);

                commands = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine($"Forward: {forwardSum}");
            Console.WriteLine($"Backwards: {backwardsSum}");
        }

        private static void InitiateCommand(string[] commands, int[] numbers)
        {
            int steps = int.Parse(commands[0]);
            string direction = commands[1].ToLower();
            int size = int.Parse(commands[2]);

            if (direction == "forward")
            {
                MoveForward(steps, size, numbers);
            }
            else if (direction == "backwards")
            {
                MoveBackwards(steps, size, numbers);
            }
        }

        private static void MoveForward(int steps, int size, int[] numbers)
        {
            for (int i = 0; i < steps; i++)
            {
                currentPoint += size;

                while (currentPoint >= numbers.Length)
                {
                    currentPoint -= numbers.Length;
                }

                forwardSum += numbers[currentPoint];
            }
        }

        private static void MoveBackwards(int steps, int size, int[] numbers)
        {
            for (int i = 0; i < steps; i++)
            {
                currentPoint -= size;

                while (currentPoint < 0)
                {
                    currentPoint += numbers.Length;
                }

                backwardsSum += numbers[currentPoint];
            }
        }
    }
}