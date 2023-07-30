namespace _09._Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double milesPerGallon = double.Parse(Console.ReadLine());

            double mile = 1.6;
            double gallon = 4.54;
            double kmsPerLiter = (100 * gallon) / (mile * milesPerGallon);

            Console.WriteLine($"{Math.Floor(kmsPerLiter)} litres per 100 km");
        }
    }
}