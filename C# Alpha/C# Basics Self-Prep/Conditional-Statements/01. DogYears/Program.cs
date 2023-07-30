namespace _01._DogYears
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int humanYears = int.Parse(Console.ReadLine());

            int dogYearsMultiplier = 10;

            int totalDogYears = 0;

            if (humanYears > 2)
            {
                totalDogYears = 20;
                humanYears -= 2;
                dogYearsMultiplier = 4;
            }

            totalDogYears += humanYears * dogYearsMultiplier;

            Console.WriteLine(totalDogYears);
        }
    }
}