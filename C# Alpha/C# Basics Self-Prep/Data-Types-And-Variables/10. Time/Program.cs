namespace _10._Time
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            int totalSeconds = seconds + (minutes * 60) + (hours * 60 * 60) + (days * 24 * 60 * 60);

            Console.WriteLine(totalSeconds);
        }
    }
}