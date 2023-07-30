namespace _04._CalculateChange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Consts
            decimal oneStotinka = 0.01m;
            decimal twoStotinka = 0.02m;
            decimal fiveStotinka = 0.05m;
            decimal tenStotinka = 0.10m;
            decimal twentyStotinka = 0.20m;
            decimal fiftyStotinka = 0.50m;
            decimal lev = 1.00m;

            decimal price = decimal.Parse(Console.ReadLine());
            decimal totalPaid = decimal.Parse(Console.ReadLine());

            decimal leftover = totalPaid - price;

            if (leftover > 0.00m)
            {
                if (leftover >= lev)
                {
                    int levToReturn = (int)Math.Floor(leftover);
                    leftover -= levToReturn;

                    Console.WriteLine($"{levToReturn} x 1 lev");
                }
                if (leftover < lev && leftover >= fiftyStotinka)
                {
                    leftover -= fiftyStotinka;
                    Console.WriteLine("1 x 50 stotinki");
                }
                if (leftover < fiftyStotinka && leftover >= twentyStotinka)
                {
                    if (leftover - twentyStotinka < twentyStotinka)
                    {
                        leftover -= twentyStotinka;
                        Console.WriteLine("1 x 20 stotinki");
                    }
                    else if (leftover - twentyStotinka >= twentyStotinka)
                    {
                        leftover -= twentyStotinka * 2;
                        Console.WriteLine("2 x 20 stotinki");
                    }
                }
                if (leftover < twentyStotinka && leftover >= tenStotinka)
                {
                    leftover -= tenStotinka;
                    Console.WriteLine("1 x 10 stotinki");
                }
                if (leftover < tenStotinka && leftover >= fiveStotinka)
                {
                    leftover -= fiveStotinka;
                    Console.WriteLine("1 x 5 stotinki");
                }
                if (leftover < fiveStotinka && leftover >= twoStotinka)
                {
                    if (leftover - twoStotinka < twoStotinka)
                    {
                        leftover -= twoStotinka;
                        Console.WriteLine("1 x 2 stotinki");
                    }
                    else if (leftover - twoStotinka >= twoStotinka)
                    {
                        leftover -= twoStotinka * 2;
                        Console.WriteLine("2 x 2 stotinki");
                    }
                }
                if (leftover < twoStotinka && leftover == oneStotinka)
                {
                    leftover -= oneStotinka;
                    Console.WriteLine("1 x 1 stotinka");
                }
            }
        }
    }
}