namespace _11._SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            int firstDigit = int.Parse(num[0].ToString());
            int secondDigit = int.Parse(num[1].ToString());
            int thirdDigit = int.Parse(num[2].ToString());
            int fourthDigit = int.Parse(num[3].ToString());

            int sum = firstDigit + secondDigit + thirdDigit + fourthDigit;

            Console.WriteLine(sum);
        }
    }
}