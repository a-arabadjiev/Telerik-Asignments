namespace _03._GuessTheSeason
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int day = int.Parse(Console.ReadLine());

            if (month == "march" && day >= 20 || month == "april" || month == "may" || month == "june" && day < 21)
            {
                Console.WriteLine("Spring");
            }
            else if (month == "june" && day >= 21 || month == "july" || month == "august" || month == "september" && day < 22)
            {
                Console.WriteLine("Summer");
            }
            else if (month == "september" && day >= 22 || month == "october" || month == "november" || month == "december" && day < 21)
            {
                Console.WriteLine("Autumn");
            }
            else if (month == "december" && day >= 21 || month == "january" || month == "february" || month == "march" && day < 20)
            {
                Console.WriteLine("Winter");
            }
        }
    }
}