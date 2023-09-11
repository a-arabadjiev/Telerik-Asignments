namespace _05._SpiralMatrix
{
    internal class Program
    {
        private static int currentDigit = 0;

        private static int[] rightStartingCoordinates = new int[2];
        private static int[] downStartingCoordinates = new int[2];
        private static int[] leftStartingCoordinates = new int[2];
        private static int[] upStartingCoordinates = new int[2];

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            rightStartingCoordinates = new int[2] { 0, 0 };
            downStartingCoordinates = new int[2] { 1, matrix.GetLength(1) - 1 };
            leftStartingCoordinates = new int[2] { matrix.GetLength(0) - 1, matrix.GetLength(1) - 2 };
            upStartingCoordinates = new int[2] { matrix.GetLength(0) - 2, 0 };

            int lastNumber = n * n;

            while (currentDigit < lastNumber)
            {
                FillRight(matrix);
                FillDown(matrix);
                FillLeft(matrix);
                FillUp(matrix);
            }

            PrintMatrix(matrix);
        }

        private static void FillRight(int[,] matrix)
        {
            for (int row = rightStartingCoordinates[0]; row < rightStartingCoordinates[0] + 1; row++)
            {
                for (int col = rightStartingCoordinates[1]; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != 0)
                    {
                        break;
                    }

                    currentDigit++;
                    matrix[row, col] = currentDigit;
                }
            }

            rightStartingCoordinates[0]++;
            rightStartingCoordinates[1]++;
        }

        private static void FillDown(int[,] matrix)
        {
            for (int col = downStartingCoordinates[1]; col < downStartingCoordinates[1] + 1; col++)
            {
                for (int row = downStartingCoordinates[0]; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] != 0)
                    {
                        break;
                    }

                    currentDigit++;
                    matrix[row, col] = currentDigit;
                }
            }
            downStartingCoordinates[0]++;
            downStartingCoordinates[1]--;
        }

        private static void FillLeft(int[,] matrix)
        {
            for (int row = leftStartingCoordinates[0]; row < leftStartingCoordinates[0] + 1; row++)
            {
                for (int col = leftStartingCoordinates[1]; col >= 0; col--)
                {
                    if (matrix[row, col] != 0)
                    {
                        break;
                    }

                    currentDigit++;
                    matrix[row, col] = currentDigit;
                }
            }
            leftStartingCoordinates[0]--; 
            leftStartingCoordinates[1]--;
        }

        private static void FillUp(int[,] matrix)
        {
            for (int col = upStartingCoordinates[1]; col < upStartingCoordinates[1] + 1; col++)
            {
                for (int row = upStartingCoordinates[0]; row > 0; row--)
                {
                    if (matrix[row, col] != 0)
                    {
                        break;
                    }

                    currentDigit++;
                    matrix[row, col] = currentDigit;
                }
            }
            upStartingCoordinates[0]--;
            upStartingCoordinates[1]++;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}