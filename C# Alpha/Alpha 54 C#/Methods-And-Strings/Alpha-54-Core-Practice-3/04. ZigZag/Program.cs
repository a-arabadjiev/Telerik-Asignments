namespace _04._ZigZag
{
    internal class Program
    {
        private static long sum = 0;

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = input[0];
            int m = input[1];

            SumZigZagPattern(n, m);

            Console.WriteLine(sum);
        }

        private static void SumZigZagPattern(int rowLength, int colLength)
        {
            int startingNumber = 1;
            int currentNumber = 1;

            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    if (col == 0)
                    {
                        if (row != 0)
                        {
                            startingNumber += 3;
                            currentNumber = startingNumber;
                        }
                    }

                    // First and last row scenario
                    if (IsRowFirstOrLast(row, rowLength))
                    {
                        if (IsRowEven(row))
                        {
                            if (IsColEven(col))
                            {
                                sum += currentNumber;
                            }
                        }
                        else
                        {
                            if (!IsColEven(col))
                            {
                                sum += currentNumber;
                            }
                        }
                    }

                    // Inner rows scenario
                    else
                    {
                        // Edge Check
                        if (IsColFirstOrLast(col, colLength))
                        {
                            if (IsRowEven(row) && col == 0)
                            {
                                sum += currentNumber;
                            }
                            else if (!IsRowEven(row) && colLength % 2 == 0 && col != 0)
                            {
                                sum += currentNumber;
                            }
                        }

                        else if (IsRowEven(row))
                        {
                            if (IsColEven(col))
                            {
                                sum += currentNumber * 2;
                            }
                        }
                        else
                        {
                            if (!IsColEven(col))
                            {
                                sum += currentNumber * 2;
                            }
                        }
                    }

                    currentNumber += 3;
                }
            }
        }

        private static bool IsRowEven(int row)
        {
            return row % 2 == 0;
        }

        private static bool IsColEven(int col)
        {
            return col % 2 == 0;
        }

        private static bool IsRowFirstOrLast(int row, int rowLength)
        {
            return row == 0 || row == rowLength - 1;
        }

        private static bool IsColFirstOrLast(int col, int colLength)
        {
            return col == 0 || col == colLength - 1;
        }
    }
}